var builder = WebApplication.CreateBuilder(args);

// ADD SERVICES TO THE CONTAINER

// Add the reverse proxy capability to the server
builder.Services.AddReverseProxy()
    .LoadFromConfig(builder.Configuration.GetSection("ReverseProxy"));

var app = builder.Build();

// CONFIGURE HTTP REQUEST PIPELINE

// Register the reverse proxy routes
app.MapReverseProxy();

app.Run();
