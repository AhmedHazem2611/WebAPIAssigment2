using Assigment2.Models;
using Assigment2.Repos.Interface;

namespace Assigment2.Repos.Implementation
{
    public class UnitOfWork : IUnitOfWork
    {
        public IMovieRepo Movie { get; }
        public ICustomerRepo Customer { get; }
        public IBookingRepo Booking { get; }
        public IGenreRepo Genre { get; }
        private readonly AppDbContext _context;

        public UnitOfWork(IMovieRepo movieRepo, ICustomerRepo customerRepo, IBookingRepo bookingRepo, IGenreRepo genreRepo, AppDbContext context)
        {
            Movie = movieRepo;
            Customer = customerRepo;
            Booking = bookingRepo;
            Genre = genreRepo;
            _context = context;
        }

        public void Save()
        {
            _context.SaveChanges();
        }
    }
}
