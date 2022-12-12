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
// if we call the graphql query may times,
// then the parallel operation cannot be handled properly and we get the below error
//"A second operation was started on this context instance before a previous operation completed. " 
//"This is usually caused by different threads concurrently
//using the same instance of DbContext. 
//https://chillicream.com/docs/hotchocolate/v11/integrations/entity-framework
builder.Services.AddPooledDbContextFactory<NorthwindContext>
    (op => op.UseSqlServer(config.GetConnectionString("NorthwindContext")));

// graphql
builder.Services
    .AddGraphQLServer()
    .AddQueryType<Queries>()
    .AddProjections() // fetch child objects customer -> orders
    //.AddFiltering()
    //.AddSorting()
    ;

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
