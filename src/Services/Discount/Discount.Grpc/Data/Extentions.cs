using Microsoft.EntityFrameworkCore;

namespace Discount.Grpc.Data
{
    public static class Extentions
    {
        public static IApplicationBuilder UseMigration(this IApplicationBuilder app)
        {
            using var scope = app.ApplicationServices.CreateScope(); // helps to get db context obj
            using var dbContext = scope.ServiceProvider.GetRequiredService<DiscountContext>(); // reach db context obj

            // now perform auto migration
            dbContext.Database.MigrateAsync();

            return app;
        }
    }
}
