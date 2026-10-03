using Assigment2.Models;
using Assigment2.Repos.Interface;
using Microsoft.EntityFrameworkCore;

namespace Assigment2.Repos.Implementation
{
    public class GenreRepo : GenericRepo<Genre>, IGenreRepo
    {
        private readonly AppDbContext _context;
        public GenreRepo(AppDbContext dbContext) : base(dbContext)
        {
            _context = dbContext;
        }

        public IEnumerable<Genre> GetGenresMovies()
        {
           return _context.Genres.Include(e => e.Movies).ToList();
        }
    }
}
