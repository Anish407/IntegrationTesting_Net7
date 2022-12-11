using StudentManagement.API.Data;
using StudentManagement.API.Models;

namespace StudentManagement.Infra.GraphQl.Sql.Queries
{
    public class Queries
    {
        public IQueryable<Customer> GetCustomers([Service] NorthwindContext context)
            => context.Customers;
    }
}
