using OperationDistributionApp.Domain.Surrogate.Response;

namespace OperationDistributionApp.Application.Interfaces
{
    public interface IDistributionService
    {
        IEnumerable<HistoryResponse> GetAll();
        void RenqueueDeploy();
        void AutomaticallyDeploy();
    }
}
