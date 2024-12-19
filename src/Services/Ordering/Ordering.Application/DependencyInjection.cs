using Microsoft.Extensions.DependencyInjection;

namespace Ordering.Application
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddApplicationServices(this IServiceCollection services)
        {
            // TODO: MediatR, Validator, Domain Event Handler and so on
            return services;
        }
    }
}
