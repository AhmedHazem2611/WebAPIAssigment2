using Assigment2.Models;

namespace Assigment2.Repos.Interface
{
    public interface IGenreRepo : IGenericRepo<Genre>
    {
        public IEnumerable<Genre> GetGenresMovies();
    }
}
