using EA.CommonLib.Mediator;
using Microsoft.Extensions.DependencyInjection;

namespace Orders.Application
{
    public static class ApplicationModule
    {
        public static void AddApplication(this IServiceCollection services)
        {
            services.RegisterMediator();
        }
        public static void RegisterMediator(this IServiceCollection services)
        {
            services.AddMediatR(config => config.RegisterServicesFromAssembly(typeof(ApplicationModule).Assembly));
            services.AddScoped<IMediatorHandler, MediatorHandler>();
        }
    }
}
