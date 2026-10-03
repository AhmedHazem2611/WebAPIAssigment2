using Assigment2.Models;
using Assigment2.Repos.Interface;
using Microsoft.EntityFrameworkCore;

namespace Assigment2.Repos.Implementation
{
    public class CustomerRepo : GenericRepo<Customer>, ICustomerRepo
    {
        private readonly AppDbContext _context;
        public CustomerRepo(AppDbContext context) : base(context)
        {
            _context = context;
        }

        public IEnumerable<Customer> GetAllCustomersByTotalSpending()
        {
            return _context.Customers.Include(e => e.Bookings).OrderByDescending(e => e.Bookings.Sum(e => e.TotalPrice)).ToList();
        }

        public IEnumerable<Customer> GetAllCustomersWithBooking()
        {
            return _context.Customers.Include(e => e.Bookings).ToList();
        }

        public IEnumerable<Customer> GetCustomersWithNoBooking()
        {
            return _context.Customers.Where(e => e.Bookings.Count == 0).ToList();
        }
    }
}
