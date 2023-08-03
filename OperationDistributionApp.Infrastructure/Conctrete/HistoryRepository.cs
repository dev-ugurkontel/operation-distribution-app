using OperationDistributionApp.Domain.Entities;
using OperationDistributionApp.Infrastructure.Abstracts;

namespace OperationDistributionApp.Infrastructure.Conctrete
{
    public class HistoryRepository : Repository<History>, IHistoryRepository
    {
        private readonly OperationDistributionAppContext _context;

        public HistoryRepository(OperationDistributionAppContext context) : base(context)
        {
            _context = context;
        }
    }
}
