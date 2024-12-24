using BuildingBlocks.Exceptions.Handler;
using Carter;

namespace Ordering.API
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddApiServices(this IServiceCollection services)
        {
            services.AddCarter();

            // Use custom exception handler is defined in `BuildingBlocks`
            services.AddExceptionHandler<CustomExceptionHandler>();

            return services;
        }

        // Additional extension method
        public static WebApplication UseApiServices(this WebApplication app)
        {
            app.MapCarter();

            app.UseExceptionHandler(options => { });

            return app;
        }
    }
}
