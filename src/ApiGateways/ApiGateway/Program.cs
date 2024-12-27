var builder = WebApplication.CreateBuilder(args);

// ADD SERVICES TO THE CONTAINER

var app = builder.Build();

// CONFIGURE HTTP REQUEST PIPELINE

app.MapGet("/", () => "Hello World!");

app.Run();
