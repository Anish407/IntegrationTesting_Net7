using Microsoft.Extensions.DependencyInjection;
using StudentManagement.Infra.Repositories.Implementation;
using StudentManagement.Infra.Repositories.Interfaces;

namespace StudentManagement.Infra.Common.Extensions
{
    public static class ServiceCollectionExtensions
    {
        public static IServiceCollection RegisterRepositories(this IServiceCollection services)
        {
            return services.AddScoped<IFamilyRepository, FamilyRepository>();
        }
    }
}
