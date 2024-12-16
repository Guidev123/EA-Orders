using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Orders.Core.Repositories;
using Orders.Infrastructure.Persistence;
using Orders.Infrastructure.Persistence.Repositories;

namespace Orders.Infrastructure
{
    public static class InfrastructureModule
    {
        public static void AddInfra(this IServiceCollection services, IConfiguration configuration)
        {
            services.ConfigureDbContext(configuration);
            services.AddRepositories();
        }

        public static void AddRepositories(this IServiceCollection services)
        {
            services.AddTransient<IOrderRepository, OrderRepository>();
            services.AddTransient<IVoucherRepository, VoucherRepository>();
        }

        public static void ConfigureDbContext(this IServiceCollection services, IConfiguration configuration) =>
            services.AddDbContext<OrderDbContext>(opt => opt.UseSqlServer(configuration.GetConnectionString("DefaultConnection")));
    }
}
