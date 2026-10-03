namespace Assigment2.Repos.Interface
{
    public interface IUnitOfWork
    {
        public IMovieRepo Movie { get; }
        public ICustomerRepo Customer { get; }
        public IBookingRepo Booking { get; }
        public IGenreRepo Genre { get; }

        public void Save();
    }
}
