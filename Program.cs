using WebApiChallenge.Models.Context;
using WebApiChallenge.Repository;
using WebApiChallenge.Repository.Implementations;
using WebApiChallenge.Services;
using WebApiChallenge.Services.Implementations;
using EvolveDb;
using Microsoft.EntityFrameworkCore;
using MySqlConnector;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddControllers();

// Database
var connection = builder.Configuration["MySQLConnection:MySQLConnectionString"];
builder.Services.AddDbContext<MySQLContext>(options => options.UseMySql(
    connection,
    new MySqlServerVersion(new Version(8, 0, 36))
    )
);

if (builder.Environment.IsDevelopment())
{
  MigrateDatabase(connection);
}

// Dependency Injection
builder.Services.AddScoped<IUserRepository, UserRepository>();
builder.Services.AddScoped<IUserService, UserServiceImplementation>();

builder.Services.AddEndpointsApiExplorer();
var app = builder.Build();

app.UseRouting();
app.MapControllers();
app.MapControllerRoute("DefaultApi", "{controller=values}/{id?}");

app.Run();

void MigrateDatabase(string connection)
{
  try
  {
    var evolveConnection = new MySqlConnection(connection);
    var evolve = new Evolve(evolveConnection)

    {
      Locations = new List<string> { "db/migrations", "db/seeders" },
      IsEraseDisabled = true,
    };

    evolve.Migrate();
  }
  catch (Exception)
  {
    throw;
  }
}