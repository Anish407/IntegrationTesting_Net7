using Microsoft.Azure.Cosmos;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudentManagement.Infra.Common.Extensions
{
    public static class CosmosServiceCollectionExtensions
    {
        public static IServiceCollection RegisterCosmos(this IServiceCollection services, IConfiguration configuration)
        {
            return services.AddSingleton(new CosmosClient(configuration["accountEndpoint"], configuration["accountKey"]));
        }
    }
}
