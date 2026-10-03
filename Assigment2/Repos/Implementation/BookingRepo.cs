using Assigment2.Models;
using Assigment2.Repos.Interface;
using Microsoft.EntityFrameworkCore;

namespace Assigment2.Repos.Implementation
{
    public class BookingRepo : GenericRepo<Booking>, IBookingRepo
    {
        private readonly AppDbContext _context;

        public BookingRepo(AppDbContext context) : base(context)
        {
            _context = context;
        }

        public IEnumerable<Booking> GetAllBookingsDetails()
        {
            return _context.Bookings.Include(e => e.Customer).Include(e => e.Movie).ThenInclude(e => e.Genre).ToList();
        }

        public IEnumerable<Booking> GetRevenueReport()
        {
            return _context.Bookings.Include(e => e.Movie).ToList();
        }
    }
}
