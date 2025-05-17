using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using DotNetEnv;
using MotoMappingApiDotnet.Src.Utils.Functions;

namespace MotoMappingApiDotnet.Src.Infra.Database
{
    public class ApplicationDbContextFactory : IDesignTimeDbContextFactory<ApplicationDbContext>
    {
        public ApplicationDbContext CreateDbContext(string[] args)
        {
            var helper = new HelperFunctions();
            helper.LoadEnvFromRoot();

            var connectionString = Environment.GetEnvironmentVariable("ORACLE_DB");

            var optionsBuilder = new DbContextOptionsBuilder<ApplicationDbContext>();
            optionsBuilder.UseOracle(connectionString);

            return new ApplicationDbContext(optionsBuilder.Options);
        }
    }
}
