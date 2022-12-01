using Microsoft.Azure.Cosmos;
using StudentManagement.Core.Entities;
using StudentManagement.Infra.cosmos;
using StudentManagement.Infra.Repositories.Interfaces;

namespace StudentManagement.Infra.Repositories.Implementation
{
    public class FamilyRepository : CosmosRepository<Family>, IFamilyRepository
    {
        public FamilyRepository(CosmosClient cosmosClient): base(cosmosClient)
        {

        }

        public override string DatabaseId => "MyData";

        public override string ContainerId => "Family";
    }
}
