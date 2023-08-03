using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using OperationDistributionApp.Infrastructure.Configs;

namespace OperationDistributionApp.Infrastructure.Contexts
{
    public class OperationDistributionAppContextFactory : IDesignTimeDbContextFactory<OperationDistributionAppContext>
    {
        public OperationDistributionAppContext CreateDbContext(string[] args)
        {
            var optionsBuilder = new DbContextOptionsBuilder<OperationDistributionAppContext>();
            optionsBuilder.UseSqlServer(ConnectionConfig.ConnectionString);

            return new OperationDistributionAppContext(optionsBuilder.Options);
        }
    }
}
