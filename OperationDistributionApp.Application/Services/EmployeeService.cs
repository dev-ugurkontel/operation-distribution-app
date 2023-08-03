using OperationDistributionApp.Domain.Entities;
using OperationDistributionApp.Application.Interfaces;
using OperationDistributionApp.Infrastructure.Abstracts;
using OperationDistributionApp.Domain.Surrogate.Request;
using OperationDistributionApp.Domain.Surrogate.Response;

namespace OperationDistributionApp.Application.Services
{
    public class EmployeeService : IEmployeeService
    {
        private readonly IEmployeeRepository _employeeRepository;

        public EmployeeService(IEmployeeRepository employeeRepository)
        {
            _employeeRepository = employeeRepository;
        }

        public IEnumerable<EmployeeResponse> GetAll()
        {
            var employees = _employeeRepository.GetAll();

            var result = employees.Select(employee => new EmployeeResponse
            {
                EmployeeID = employee.EmployeeID,
                Name = employee.Name,
                Surname = employee.Surname,
                //Histories = employee.Histories.Select(history => new HistoryResponse
                //{
                //    HistoryID = history.HistoryID,
                //    EmployeeID = history.EmployeeID,
                //    OperationID = history.OperationID,
                //    IsActive = history.IsActive,
                //    CreatedAt = history.CreatedAt
                //}).ToList()
            }).ToList();

            return result;
        }

        public EmployeeResponse GetById(int id)
        {
            var employee = _employeeRepository.GetById(id);

            var result = new EmployeeResponse
            {
                EmployeeID = employee.EmployeeID,
                Name = employee.Name,
                Surname = employee.Surname,
                //Histories = employee.Histories.Select(history => new HistoryResponse
                //{
                //    HistoryID = history.HistoryID,
                //    EmployeeID = history.EmployeeID,
                //    OperationID = history.OperationID,
                //    IsActive = history.IsActive,
                //    CreatedAt = history.CreatedAt
                //}).ToList()
            };

            return result;
        }

        public void Add(EmployeeRequest data)
        {
            Employee entity = new()
            {
                Name = data.Name,
                Surname = data.Surname
            };

            _employeeRepository.Add(entity);
        }

        public void Update(int id, EmployeeRequest data)
        {
            var entity = _employeeRepository.GetById(id);
            entity.Name = data.Name;
            entity.Surname = data.Surname;

            _employeeRepository.Update(entity);
        }

        public void Delete(int id)
        {
            var entity = _employeeRepository.GetById(id);
            _employeeRepository.Delete(entity);
        }
    }
}
