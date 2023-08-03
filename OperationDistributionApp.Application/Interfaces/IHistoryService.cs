using OperationDistributionApp.Domain.Surrogate.Request;
using OperationDistributionApp.Domain.Surrogate.Response;

namespace OperationDistributionApp.Application.Interfaces
{
    public interface IHistoryService
    {
        IEnumerable<HistoryResponse> GetAll();
        void AddRange(IEnumerable<HistoryRequest> entities);
    }
}
