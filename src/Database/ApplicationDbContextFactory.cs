using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using DotNetEnv;

namespace Src.Database
{
    public class ApplicationDbContextFactory : IDesignTimeDbContextFactory<ApplicationDbContext>
    {
        public ApplicationDbContext CreateDbContext(string[] args)
        {
            Env.Load();

            var connectionString = Environment.GetEnvironmentVariable("ORACLE_DB");

            var optionsBuilder = new DbContextOptionsBuilder<ApplicationDbContext>();
            optionsBuilder.UseOracle(connectionString);

            return new ApplicationDbContext(optionsBuilder.Options);
        }
    }
}
