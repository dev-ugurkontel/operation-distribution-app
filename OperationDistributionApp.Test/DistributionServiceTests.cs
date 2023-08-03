using Xunit;
using Xunit.Abstractions;
using Moq;
using Hangfire;
using Hangfire.Common;
using Hangfire.States;
using OperationDistributionApp.Application.Interfaces;
using OperationDistributionApp.Application.Services;
using OperationDistributionApp.Domain.Entities;
using OperationDistributionApp.Infrastructure.Abstracts;

namespace OperationDistributionApp.Test
{
    public class DistributionServiceTests
    {
        private readonly ITestOutputHelper output;
        private readonly IDistributionService _distributionService;
        private IBackgroundJobClient _jobClient;
        private IEmployeeService _employeeService;
        private IOperationService _operationService;
        private IHistoryService _historyService;

        public DistributionServiceTests(ITestOutputHelper output)
        {
            this.output = output;

            var employees = new List<Employee>
            {
                new Employee { EmployeeID = 1, Name = "John", Surname = "Smith" },
                new Employee { EmployeeID = 2, Name = "Emily", Surname = "Johnson" },
                new Employee { EmployeeID = 3, Name = "Michael", Surname = "Williams" },
                new Employee { EmployeeID = 4, Name = "Sarah", Surname = "Jones" },
                new Employee { EmployeeID = 5, Name = "David", Surname = "Brown" },
                new Employee { EmployeeID = 6, Name = "Jennifer", Surname = "Wilson" }
            };

            var operations = new List<Operation>
            {
                new Operation { OperationID = 1, Name = "Welding Chassis", Difficulty = 1 },
                new Operation { OperationID = 2, Name = "Assembling Engine Blocks", Difficulty = 2 },
                new Operation { OperationID = 3, Name = "Installing Wiring Harnesses", Difficulty = 3 },
                new Operation { OperationID = 4, Name = "Attaching Body Panels", Difficulty = 4 },
                new Operation { OperationID = 5, Name = "Painting Car Bodies", Difficulty = 5 },
                new Operation { OperationID = 6, Name = "Fitting Interior Components", Difficulty = 6 }
            };

            var histories = new List<History>
            {
                new History { HistoryID = 1, EmployeeID = 1, OperationID = 1, IsActive = true, CreatedAt = DateTime.Now },
                new History { HistoryID = 2, EmployeeID = 2, OperationID = 2, IsActive = true, CreatedAt = DateTime.Now },
                new History { HistoryID = 3, EmployeeID = 3, OperationID = 3, IsActive = true, CreatedAt = DateTime.Now },
                new History { HistoryID = 4, EmployeeID = 4, OperationID = 4, IsActive = true, CreatedAt = DateTime.Now },
                new History { HistoryID = 5, EmployeeID = 5, OperationID = 5, IsActive = true, CreatedAt = DateTime.Now },
                new History { HistoryID = 6, EmployeeID = 6, OperationID = 6, IsActive = true, CreatedAt = DateTime.Now }
            };

            var mockBackgroundJobClient = new Mock<IBackgroundJobClient>();
            var mockEmployeeRepo = new Mock<IEmployeeRepository>();
            var mockOperationRepo = new Mock<IOperationRepository>();
            var mockHistoryRepo = new Mock<IHistoryRepository>();

            mockEmployeeRepo.Setup(repo => repo.GetAll()).Returns(employees);
            mockOperationRepo.Setup(repo => repo.GetAll()).Returns(operations);
            mockHistoryRepo.Setup(repo => repo.GetAll()).Returns(histories);
            mockBackgroundJobClient.Setup(client => client.Create(It.IsAny<Job>(), It.IsAny<IState>())).Returns("JobId");

            _jobClient = mockBackgroundJobClient.Object;
            _employeeService = new EmployeeService(mockEmployeeRepo.Object);
            _operationService = new OperationService(mockOperationRepo.Object);
            _historyService = new HistoryService(mockHistoryRepo.Object);
            _distributionService = new DistributionService(_jobClient, _employeeService, _operationService, _historyService);
        }

        [Fact]
        public void GetAll()
        {
            var result = _distributionService.GetAll();
            Assert.NotNull(result);
            Assert.True(result.Count() > 0);

            output.WriteLine("The test has been completed successfully.");
        }

        [Fact]
        public void RenqueueDeploy()
        {
            _distributionService.RenqueueDeploy();

            output.WriteLine("The test has been completed successfully.");
        }
    }
}
