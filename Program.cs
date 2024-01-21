using EvolveDb;
using Microsoft.EntityFrameworkCore;
using MySqlConnector;
using WebApiChallenge.Models.Context;

var builder = WebApplication.CreateBuilder(args);

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

var app = builder.Build();
app.MapGet("/", () => "It works!");

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