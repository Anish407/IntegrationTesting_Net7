using Microsoft.EntityFrameworkCore;
using StudentManagement.API.Data;
using StudentManagement.API.Models;

namespace StudentManagement.Infra.GraphQl.Descriptions
{
    public class CustomerType: ObjectType<Customer>
    {
        protected override void Configure(IObjectTypeDescriptor<Customer> descriptor)
        {
            descriptor.Authorize(new[] { "Guest", "Administrator" });
            descriptor.Description("Customer class");
            descriptor.Field(f => f.Orders).Description("Customers Orders");
            descriptor.Field(f => f.Orders).Authorize(new[] { "Administrator" });
        }

        private class CustomerResolver
        {
            public IQueryable<Customer> GetCustomersById(Customer customer, 
                [ScopedService]NorthwindContext northwindContext)
            {
                return northwindContext.Customers
                    .Where(i => i.CustomerId == customer.CustomerId);
            }
        }
    }
}
