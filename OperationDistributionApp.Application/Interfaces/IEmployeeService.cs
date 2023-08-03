using OperationDistributionApp.Domain.Surrogate.Request;
using OperationDistributionApp.Domain.Surrogate.Response;

namespace OperationDistributionApp.Application.Interfaces
{
    public interface IEmployeeService
    {
        IEnumerable<EmployeeResponse> GetAll();
        EmployeeResponse GetById(int id);
        void Add(EmployeeRequest data);
        void Update(int id, EmployeeRequest data);
        void Delete(int id);
    }
}
