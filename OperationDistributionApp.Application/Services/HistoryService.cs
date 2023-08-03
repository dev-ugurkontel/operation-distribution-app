using OperationDistributionApp.Application.Interfaces;
using OperationDistributionApp.Domain.Entities;
using OperationDistributionApp.Domain.Surrogate.Request;
using OperationDistributionApp.Domain.Surrogate.Response;
using OperationDistributionApp.Infrastructure.Abstracts;

namespace OperationDistributionApp.Application.Services
{
    public class HistoryService : IHistoryService
    {
        private readonly IHistoryRepository _historyRepository;

        public HistoryService(IHistoryRepository historyRepository) 
        {
            _historyRepository = historyRepository;
        }

        public void AddRange(IEnumerable<HistoryRequest> data)
        {
            var histories = _historyRepository.GetAll();
            if (histories.Any())
            {
                foreach (var history in histories)
                {
                    history.IsActive = false;
                }
                _historyRepository.UpdateRange(histories);
            }

            var entities = data.Select(request => new History
            {
                EmployeeID = request.EmployeeID,
                OperationID = request.OperationID,
                IsActive = request.IsActive,
                CreatedAt = DateTime.Now
            });

            _historyRepository.AddRange(entities);
        }

        public IEnumerable<HistoryResponse> GetAll()
        {
            var histories = _historyRepository.GetAll();

            var responses = histories.Select(history => new HistoryResponse
            {
                HistoryID = history.HistoryID,
                EmployeeID = history.EmployeeID,
                OperationID = history.OperationID,
                IsActive = history.IsActive,
                CreatedAt = history.CreatedAt
            }).ToList().OrderByDescending(x => x.HistoryID);

            return responses;
        }
    }
}
