namespace Assigment2.Repos.Interface
{
    public interface IGenericRepo<T> where T : class
    {
        public void Add(T item);
        public void Delete(T item);
        public void Update(T item);
        public T? GetById(int ID);
        public IEnumerable<T> GetAll();

    }
}
