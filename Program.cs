var builder = WebApplication.CreateBuilder(args);
var app = builder.Build();

app.MapGet("/", () => "It works!");

app.Run();
