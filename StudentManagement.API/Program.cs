using GraphQL.Server.Ui.Voyager;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Diagnostics.HealthChecks;
using StudentManagement.API.Data;
using StudentManagement.Infra.GraphQl.Sql.Queries;

var builder = WebApplication.CreateBuilder(args);
var config = builder.Configuration;
// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddDbContextPool<NorthwindContext>
    (op => op.UseSqlServer(config.GetConnectionString("NorthwindContext")));

// graphql
builder.Services
    .AddGraphQLServer()
    .AddQueryType<Queries>();

builder.Services.AddSwaggerGen();
builder.Services.AddHealthChecks()
    .AddCheck("Sample", () => HealthCheckResult.Healthy("All good."));

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.UseHealthChecks("/healthz");
app.MapControllers();

//https://localhost:7155/graphql/ --> we get a UI like swagger
app.MapGraphQL("/graphql");

// add voyager -- UI that shows a more descriptive version of the query
app.MapGraphQLVoyager(pattern: "api/graphqlvoyager", new VoyagerOptions
{
    GraphQLEndPoint="/graphql"
});

app.Run();
public partial class Program { }
