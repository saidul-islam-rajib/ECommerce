using Microsoft.AspNetCore.RateLimiting;

var builder = WebApplication.CreateBuilder(args);

// ADD SERVICES TO THE CONTAINER

// Add the reverse proxy capability to the server
builder.Services.AddReverseProxy()
    .LoadFromConfig(builder.Configuration.GetSection("ReverseProxy"));

builder.Services.AddRateLimiter(options =>
{
    options.AddFixedWindowLimiter("customPolicy", opt =>
    {
        opt.PermitLimit = 5;
        opt.Window = TimeSpan.FromSeconds(12);
    });
});

var app = builder.Build();

// CONFIGURE HTTP REQUEST PIPELINE

app.UseRateLimiter(); // Add rate limiter middleware
app.MapReverseProxy(); // Add reverse proxy middleware

app.Run();
