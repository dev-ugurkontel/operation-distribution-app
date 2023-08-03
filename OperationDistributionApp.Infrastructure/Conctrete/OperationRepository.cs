using OperationDistributionApp.Domain.Entities;
using OperationDistributionApp.Infrastructure.Abstracts;

namespace OperationDistributionApp.Infrastructure.Conctrete
{
    public class OperationRepository : Repository<Operation>, IOperationRepository
    {
        private readonly OperationDistributionAppContext _context;

        public OperationRepository(OperationDistributionAppContext context) : base(context)
        {
            _context = context;
        }
    }
}