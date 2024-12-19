var builder = WebApplication.CreateBuilder(args);

// ............ ADD SERVICES TO THE DI CONTAINER ............


var app = builder.Build();


// ............ CONFIGURE HTTP REQUEST PIPELINE ............


app.Run();
