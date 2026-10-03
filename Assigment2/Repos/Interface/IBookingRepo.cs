using Assigment2.Models;

namespace Assigment2.Repos.Interface
{
    public interface IBookingRepo : IGenericRepo<Booking>
    {
        public IEnumerable<Booking> GetAllBookingsDetails();
        public IEnumerable<Booking> GetRevenueReport();
    }
}
