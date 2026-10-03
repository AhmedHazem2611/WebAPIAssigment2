using Assigment2.Models;
using Assigment2.Repos.Interface;

namespace Assigment2.Repos.Implementation
{
    public class GenericRepo<T> : IGenericRepo<T> where T : class
    {
        private readonly AppDbContext _context;
        public GenericRepo(AppDbContext dbContext)
        {
            _context = dbContext;
        }

        public void Add(T item)
        {
            _context.Set<T>().Add(item);
        }

        public void Delete(T item)
        {
            _context.Set<T>().Remove(item);
        }

        public IEnumerable<T> GetAll()
        {
            return _context.Set<T>().ToList();
        }

        public T? GetById(int ID)
        {
            return _context.Set<T>().Find(ID);
        }

        public void Update(T item)
        {
            _context.Set<T>().Update(item);
        }
    }
}
