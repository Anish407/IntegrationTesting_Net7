using StudentManagement.API.Data;
using StudentManagement.API.Models;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory;

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
        [UseProjection] // fetch child objects
        public IQueryable<Customer> GetCustomers([ScopedService] NorthwindContext context)
            => context.Customers;
    }
}
