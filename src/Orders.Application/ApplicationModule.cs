using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Orders.Application.Services.Interfaces;
using Orders.Application.UseCases;
using SharedLib.Domain.Mediator;
using SharedLib.MessageBus;

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
            services.AddHttpContextAccessor();
            services.AddMediatR(config => config.RegisterServicesFromAssembly(typeof(ApplicationModule).Assembly));
            services.AddScoped<IMediatorHandler, MediatorHandler>();
            services.AddTransient<IUserService, UserService>();
        }

        public static void AddMessageBusConfiguration(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddMessageBus(configuration.GetMessageQueueConnection("MessageBus"));
        }
    }
}
