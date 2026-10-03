using Assigment2.Models;
using Assigment2.Repos.Interface;
using Microsoft.EntityFrameworkCore;

namespace Assigment2.Repos.Implementation
{
    public class MovieRepo : GenericRepo<Movie>, IMovieRepo
    {
        private readonly AppDbContext _context;
        public MovieRepo(AppDbContext context) : base(context) 
        {
            _context = context;
        }

        public IEnumerable<Movie> GetAvailableMovies()
        {
           return _context.Movies.Where(e => e.AvailableSeats >  0).ToList();
        }

        public decimal GetAveragePriceTicket()
        {
            return _context.Movies.Average(e => e.TicketPrice);
        }

        public Movie GetLatestMovie()
        {
            return _context.Movies.OrderBy(e => e.ReleaseYear).Last();
        }

        public Movie GetMostBookedMovie()
        {
            return _context.Movies.OrderBy(e => e.Bookings.Count).Last();
        }

        public Movie GetMovieByTitle(string title)
        {
            return _context.Movies.FirstOrDefault(e => e.Title == title);
        }

        public IEnumerable<Movie> GetMoviesBetweenPrice(int min, int max)
        {
            return _context.Movies.Where(e => e.TicketPrice >= min && e.TicketPrice <= max);
        }

        public int GetMoviesCount()
        {
            return _context.Movies.Count();
        }

        public IEnumerable<Movie> GetMoviesGreaterThanRating(int rating)
        {
           return _context.Movies.Where(e => e.Rating >= rating).ToList();
        }

        public IEnumerable<Movie> GetMoviesPage(int PageNumber, int PageSize)
        {
            return _context.Movies
                .Skip((PageNumber - 1) * PageSize)
                .Take(PageSize)
                .ToList();
        }

        public IEnumerable<Movie> GetMoviesWithGenreDetails()
        {
            return _context.Movies.Include(e => e.Genre).ToList();
        }

        public IEnumerable<Movie> GetTop5Movies()
        {
            return _context.Movies.OrderByDescending(e => e.Rating).Take(5).ToList();
        }
    }
}
