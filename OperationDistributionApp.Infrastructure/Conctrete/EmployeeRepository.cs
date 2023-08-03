using OperationDistributionApp.Domain.Entities;
using OperationDistributionApp.Infrastructure.Abstracts;

namespace OperationDistributionApp.Infrastructure.Conctrete
{
    public class EmployeeRepository : Repository<Employee>, IEmployeeRepository
    {
        private readonly OperationDistributionAppContext _context;

        public EmployeeRepository(OperationDistributionAppContext context) : base(context)
        {
            _context = context;
        }
    }
}   
