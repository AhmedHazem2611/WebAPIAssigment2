using Microsoft.EntityFrameworkCore;

namespace Assigment2.Models
{
    public class AppDbContext : DbContext
    {
        public DbSet<Movie> Movies { get; set; }
        public DbSet<Customer> Customers    { get; set; }
        public DbSet<Genre> Genres { get; set; }
        public DbSet<Booking> Bookings { get; set; }
        public AppDbContext(DbContextOptions options) : base(options)
        {
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Genre>()
                .HasMany(e => e.Movies)
                .WithOne(s => s.Genre)
                .HasForeignKey(e => e.GenreId);

            modelBuilder.Entity<Customer>()
                .HasMany(e => e.Bookings)
                .WithOne(s => s.Customer)
                .HasForeignKey(e => e.CustomerId);

            modelBuilder.Entity<Movie>()
                .HasMany(e => e.Bookings)
                .WithOne(s => s.Movie)
                .HasForeignKey(e => e.MovieId);

            modelBuilder.Entity<Genre>()
                .HasIndex(e => e.Name)
                .IsUnique();

            modelBuilder.Entity<Movie>()
                .HasIndex(e => e.Title)
                .IsUnique();

            modelBuilder.Entity<Customer>()
                .HasIndex(e => e.Email)
                .IsUnique();

            modelBuilder.Entity<Booking>()
                .Property(e => e.BookingDate)
                .HasDefaultValueSql("GETDATE()");

            modelBuilder.Entity<Movie>()
                .Property(e => e.TicketPrice)
                .HasPrecision(10, 2);


            // =========================
            // Genres
            // =========================

            modelBuilder.Entity<Genre>().HasData(
                new Genre { Id = 1, Name = "Action" },
                new Genre { Id = 2, Name = "Comedy" },
                new Genre { Id = 3, Name = "Drama" },
                new Genre { Id = 4, Name = "Horror" },
                new Genre { Id = 5, Name = "Science Fiction" }
            );


            // =========================
            // Movies
            // =========================

            modelBuilder.Entity<Movie>().HasData(
                new Movie
                {
                    Id = 1,
                    Title = "Inception",
                    Director = "Christopher Nolan",
                    Duration = 148,
                    ReleaseYear = 2010,
                    Rating = 9,
                    TicketPrice = 150,
                    AvailableSeats = 50,
                    GenreId = 5
                },

                new Movie
                {
                    Id = 2,
                    Title = "The Dark Knight",
                    Director = "Christopher Nolan",
                    Duration = 152,
                    ReleaseYear = 2008,
                    Rating = 9,
                    TicketPrice = 180,
                    AvailableSeats = 45,
                    GenreId = 1
                },

                new Movie
                {
                    Id = 3,
                    Title = "The Hangover",
                    Director = "Todd Phillips",
                    Duration = 100,
                    ReleaseYear = 2009,
                    Rating = 8,
                    TicketPrice = 120,
                    AvailableSeats = 60,
                    GenreId = 2
                },

                new Movie
                {
                    Id = 4,
                    Title = "The Shawshank Redemption",
                    Director = "Frank Darabont",
                    Duration = 142,
                    ReleaseYear = 1994,
                    Rating = 10,
                    TicketPrice = 140,
                    AvailableSeats = 40,
                    GenreId = 3
                },

                new Movie
                {
                    Id = 5,
                    Title = "Interstellar",
                    Director = "Christopher Nolan",
                    Duration = 169,
                    ReleaseYear = 2014,
                    Rating = 9,
                    TicketPrice = 170,
                    AvailableSeats = 55,
                    GenreId = 5
                },

                new Movie
                {
                    Id = 6,
                    Title = "It",
                    Director = "Andy Muschietti",
                    Duration = 135,
                    ReleaseYear = 2017,
                    Rating = 7,
                    TicketPrice = 130,
                    AvailableSeats = 35,
                    GenreId = 4
                },

                new Movie
                {
                    Id = 7,
                    Title = "Forrest Gump",
                    Director = "Robert Zemeckis",
                    Duration = 142,
                    ReleaseYear = 1994,
                    Rating = 9,
                    TicketPrice = 130,
                    AvailableSeats = 50,
                    GenreId = 3
                },

                new Movie
                {
                    Id = 8,
                    Title = "Gladiator",
                    Director = "Ridley Scott",
                    Duration = 155,
                    ReleaseYear = 2000,
                    Rating = 9,
                    TicketPrice = 160,
                    AvailableSeats = 45,
                    GenreId = 1
                }
            );


            // =========================
            // Customers
            // =========================

            modelBuilder.Entity<Customer>().HasData(
                new Customer
                {
                    Id = 1,
                    FullName = "Ahmed Ali",
                    Email = "ahmed@gmail.com",
                    Phone = "01012345678"
                },

                new Customer
                {
                    Id = 2,
                    FullName = "Omar Hassan",
                    Email = "omar@gmail.com",
                    Phone = "01112345678"
                },

                new Customer
                {
                    Id = 3,
                    FullName = "Mohamed Samir",
                    Email = "mohamed@gmail.com",
                    Phone = "01212345678"
                },

                new Customer
                {
                    Id = 4,
                    FullName = "Youssef Ibrahim",
                    Email = "youssef@gmail.com",
                    Phone = "01512345678"
                },

                new Customer
                {
                    Id = 5,
                    FullName = "Karim Mahmoud",
                    Email = "karim@gmail.com",
                    Phone = "01098765432"
                }
            );


            // =========================
            // Bookings
            // =========================

            modelBuilder.Entity<Booking>().HasData(
                new Booking
                {
                    Id = 1,
                    BookingDate = new DateTime(2026, 9, 25),
                    NumberOfTickets = 2,
                    TotalPrice = 300,
                    CustomerId = 1,
                    MovieId = 1
                },

                new Booking
                {
                    Id = 2,
                    BookingDate = new DateTime(2026, 9, 26),
                    NumberOfTickets = 3,
                    TotalPrice = 540,
                    CustomerId = 2,
                    MovieId = 2
                },

                new Booking
                {
                    Id = 3,
                    BookingDate = new DateTime(2026, 9, 27),
                    NumberOfTickets = 2,
                    TotalPrice = 240,
                    CustomerId = 3,
                    MovieId = 3
                },

                new Booking
                {
                    Id = 4,
                    BookingDate = new DateTime(2026, 9, 28),
                    NumberOfTickets = 1,
                    TotalPrice = 170,
                    CustomerId = 4,
                    MovieId = 5
                },

                new Booking
                {
                    Id = 5,
                    BookingDate = new DateTime(2026, 9, 29),
                    NumberOfTickets = 4,
                    TotalPrice = 520,
                    CustomerId = 5,
                    MovieId = 6
                }
            );
        }
    }
}
