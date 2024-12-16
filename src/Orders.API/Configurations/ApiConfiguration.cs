using Orders.Application;
using Orders.Infrastructure;

namespace Orders.API.Configurations
{
    public static class ApiConfiguration
    {
        public static void ApplyApiConfigurations(this WebApplicationBuilder builder)
        {
            builder.Services.AddInfra(builder.Configuration);
            builder.Services.AddApplication();
        }
    }
}
