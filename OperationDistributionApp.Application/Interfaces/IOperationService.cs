using OperationDistributionApp.Domain.Surrogate.Request;
using OperationDistributionApp.Domain.Surrogate.Response;

namespace OperationDistributionApp.Application.Interfaces
{
    public interface IOperationService
    {
        IEnumerable<OperationResponse> GetAll();
        OperationResponse GetById(int id);
        void Add(OperationRequest data);
        void Update(int id, OperationRequest data);
        void Delete(int id);
    }
}
