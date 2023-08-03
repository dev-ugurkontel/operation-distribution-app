using Hangfire;
using OperationDistributionApp.Application.Interfaces;
using OperationDistributionApp.Domain.Surrogate.Request;
using OperationDistributionApp.Domain.Surrogate.Response;

namespace OperationDistributionApp.Application.Services
{
    public class DistributionService : IDistributionService
    {
        private readonly IBackgroundJobClient _jobClient;
        private readonly IEmployeeService _employeeService;
        private readonly IOperationService _operationService;
        private readonly IHistoryService _historyService;

        public DistributionService(
            IBackgroundJobClient jobClient,
            IEmployeeService employeeService, 
            IOperationService operationService,
            IHistoryService historyService)
        {
            _jobClient = jobClient;
            _employeeService = employeeService;
            _operationService = operationService;
            _historyService = historyService;
        }

        public IEnumerable<HistoryResponse> GetAll()
        {
            var histories = _historyService.GetAll();
            var employees = _employeeService.GetAll();
            var operations = _operationService.GetAll();

            var result = histories.Select(history => new HistoryResponse
            {
                HistoryID = history.HistoryID,
                EmployeeID = history.EmployeeID,
                OperationID = history.OperationID,
                IsActive = history.IsActive,
                CreatedAt = history.CreatedAt,
                Difficulty = operations.FirstOrDefault(operation => operation.OperationID == history.OperationID)?.Difficulty ?? 0,
                Employee = employees.FirstOrDefault(employee => employee.EmployeeID == history.EmployeeID),
                Operation = operations.FirstOrDefault(operation => operation.OperationID == history.OperationID)
            });

            return result;
        }

        public void RenqueueDeploy()
        {
            _jobClient.Enqueue(() => AutomaticallyDeploy());
        }

        public void AutomaticallyDeploy()
        {
            List<HistoryRequest> assignments = new List<HistoryRequest>();
            var employees = _employeeService.GetAll().ToList();
            var operations = _operationService.GetAll().ToList();

            bool success = AssignOperations(employees, operations, assignments);

            if (success)
            {
                _historyService.AddRange(assignments);
            }
            else
            {
                throw new Exception("An error occurred while assigning operations.");
            }
        }

        private bool AssignOperations(List<EmployeeResponse> employees, List<OperationResponse> operations, List<HistoryRequest> assignments)
        {
            var availableOperations = new List<OperationResponse>(operations);
            var histories = _historyService.GetAll().ToList();

            foreach (var employee in employees)
            {
                var lastOperation = histories
                    .Where(history => history.EmployeeID == employee.EmployeeID)
                    .OrderByDescending(history => history.CreatedAt)
                    .FirstOrDefault();

                var forbiddenDifficulties = new List<byte>();

                if (lastOperation is not null)
                {
                    lastOperation.Difficulty = operations.FirstOrDefault(operation => operation.OperationID == lastOperation.OperationID)?.Difficulty ?? 0;

                    forbiddenDifficulties.Add(lastOperation.Difficulty);

                    if (lastOperation.Difficulty > 1)
                    {
                        forbiddenDifficulties.Add((byte)(lastOperation.Difficulty - 1));
                    }
                    if (lastOperation.Difficulty < availableOperations.Max(o => o.Difficulty))
                    {
                        forbiddenDifficulties.Add((byte)(lastOperation.Difficulty + 1));
                    }
                }

                var possibleOperations = availableOperations.Where(o => !forbiddenDifficulties.Contains(o.Difficulty)).ToList();
                if (possibleOperations.Any())
                {
                    var randomOperation = possibleOperations.OrderBy(o => Guid.NewGuid()).FirstOrDefault();
                    assignments.Add(new HistoryRequest
                    {
                        EmployeeID = employee.EmployeeID,
                        OperationID = randomOperation.OperationID,
                        IsActive = true
                    });

                    availableOperations.Remove(randomOperation);
                }
                else
                {
                    assignments.Clear();
                    return AssignOperations(employees, operations, assignments);
                }
            }

            return true;
        }



    }
}
