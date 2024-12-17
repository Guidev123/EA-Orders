using EA.CommonLib.Mediator;
using EA.CommonLib.MessageBus;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Orders.Application
{
    public static class ApplicationModule
    {
        public static void AddApplication(this IServiceCollection services, IConfiguration configuration)
        {
            services.RegisterMediator();
            services.AddMessageBusConfiguration(configuration);
        }
        public static void RegisterMediator(this IServiceCollection services)
        {
            services.AddMediatR(config => config.RegisterServicesFromAssembly(typeof(ApplicationModule).Assembly));
            services.AddScoped<IMediatorHandler, MediatorHandler>();
        }

        public static void AddMessageBusConfiguration(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddMessageBus(configuration.GetMessageQueueConnection("MessageBus"));
        }
    }
}
