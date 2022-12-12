using StudentManagement.API.Data;
using StudentManagement.API.Models;

namespace StudentManagement.Infra.GraphQl.Sql.Queries
{
    public class Queries
    {
        // used while retrieving parallel results
        //        query{
        //    a:customers{
        //        customerId
        //        companyName
        //    }
        //    b:customers{
        //        customerId
        //        companyName
        //    }
        //c: customers{
        //    customerId
        //    companyName
        //    }
        //}
        [UseDbContext(typeof(NorthwindContext))]
        public IQueryable<Customer> GetCustomers([ScopedService] NorthwindContext context)
            => context.Customers;
    }
}
