namespace Ordering.API
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddApiServices(this IServiceCollection services)
        {
            // TODO: Before building the application thing will be here


            return services;
        }

        // Additional extension method
        public static WebApplication UseApiServices(this WebApplication app)
        {
            // After building the operations will be here

            return app;
        }
    }
}
