using Assigment2.Models;

namespace Assigment2.Repos.Interface
{
    public interface IMovieRepo : IGenericRepo<Movie>
    {
        public Movie GetMovieByTitle(string title);
        public IEnumerable<Movie> GetMoviesGreaterThanRating(int rating);
        public IEnumerable<Movie> GetMoviesBetweenPrice(int min, int max);
        public IEnumerable<Movie> GetAvailableMovies();
        public IEnumerable<Movie> GetTop5Movies();
        public Movie GetLatestMovie();
        public Movie GetMostBookedMovie();
        public int GetMoviesCount();
        public decimal GetAveragePriceTicket();
        public IEnumerable<Movie> GetMoviesWithGenreDetails();
        public IEnumerable<Movie> GetMoviesPage(int PageNumber, int PageSize);
    }
}
