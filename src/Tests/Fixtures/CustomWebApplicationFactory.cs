using Microsoft.AspNetCore.Mvc.Testing;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.EntityFrameworkCore;
using MotoMappingApiDotnet.Src.Infra.Database;
using Microsoft.AspNetCore.Hosting;

public class CustomWebApplicationFactory : WebApplicationFactory<Program>
{
    protected override void ConfigureWebHost(IWebHostBuilder builder)
    {
        builder.UseEnvironment("Testing"); // << IMPORTANTE

        builder.ConfigureServices(services =>
        {
            // Remove qualquer DB real
            var descriptor = services.SingleOrDefault(
                s => s.ServiceType == typeof(DbContextOptions<ApplicationDbContext>)
            );

            if (descriptor != null)
                services.Remove(descriptor);

            // Adiciona DB em memória
            services.AddDbContext<ApplicationDbContext>(options =>
                options.UseInMemoryDatabase("TestDB"));
        });
    }
}
