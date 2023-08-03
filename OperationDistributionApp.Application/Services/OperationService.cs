using OperationDistributionApp.Application.Interfaces;
using OperationDistributionApp.Domain.Entities;
using OperationDistributionApp.Domain.Surrogate.Request;
using OperationDistributionApp.Domain.Surrogate.Response;
using OperationDistributionApp.Infrastructure.Abstracts;

namespace OperationDistributionApp.Application.Services
{
    public class OperationService : IOperationService
    {
        private readonly IOperationRepository _operationRepository;

        public OperationService(IOperationRepository operationRepository)
        {
            _operationRepository = operationRepository;
        }

        public IEnumerable<OperationResponse> GetAll()
        {
            var operations = _operationRepository.GetAll();

            var result = operations.Select(operation => new OperationResponse
            {
                OperationID = operation.OperationID,
                Name = operation.Name,
                Difficulty = operation.Difficulty,
                //Histories = operation.Histories.Select(history => new HistoryResponse
                //{
                //    HistoryID = history.HistoryID,
                //    EmployeeID = history.EmployeeID,
                //    OperationID = history.OperationID,
                //    IsActive = history.IsActive,
                //    CreatedAt = history.CreatedAt
                //})
            }).ToList();

            return result;
        }

        public OperationResponse GetById(int id)
        {
            var operation = _operationRepository.GetById(id);

            var result = new OperationResponse
            {
                OperationID = operation.OperationID,
                Name = operation.Name,
                Difficulty = operation.Difficulty,
                //Histories = operation.Histories.Select(history => new HistoryResponse
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

        public void Add(OperationRequest data)
        {
            Operation entity = new()
            {
                Name = data.Name,
                Difficulty = data.Difficulty
            };

            _operationRepository.Add(entity);
        }

        public void Update(int id, OperationRequest data)
        {
            var entity = _operationRepository.GetById(id);
            entity.Name = data.Name;
            entity.Difficulty = data.Difficulty;

            _operationRepository.Update(entity);
        }

        public void Delete(int id)
        {
            var entity = _operationRepository.GetById(id);
            _operationRepository.Delete(entity);
        }
    }
}
