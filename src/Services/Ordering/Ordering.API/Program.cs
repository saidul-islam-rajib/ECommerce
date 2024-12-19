using Ordering.API;
using Ordering.Application;
using Ordering.Infrastructure;

var builder = WebApplication.CreateBuilder(args);

// ............ ADD SERVICES TO THE DI CONTAINER ............
builder.Services
    .AddApplicationServices()
    .AddInfrastructureServices(builder.Configuration)
    .AddApiServices();

var app = builder.Build();


// ............ CONFIGURE HTTP REQUEST PIPELINE ............


app.Run();
