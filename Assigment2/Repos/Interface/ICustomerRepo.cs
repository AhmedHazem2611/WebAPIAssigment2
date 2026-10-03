using Assigment2.Models;

namespace Assigment2.Repos.Interface
{
    public interface ICustomerRepo : IGenericRepo<Customer>
    {
        public IEnumerable<Customer> GetAllCustomersWithBooking();
        public IEnumerable<Customer> GetAllCustomersByTotalSpending();
        public IEnumerable<Customer> GetCustomersWithNoBooking();
    }
}
