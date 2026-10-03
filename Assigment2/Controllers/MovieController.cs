using Assigment2.DTOs;
using Assigment2.Models;
using Assigment2.Repos.Interface;
using Microsoft.AspNetCore.Mvc;

namespace Assigment2.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MovieController : ControllerBase
    {
        private readonly IUnitOfWork _unitofwork;

        public MovieController(IUnitOfWork unitofwork)
        {
            _unitofwork = unitofwork;
        }

        [HttpGet]
        public IActionResult GetAll()
        {
            var Movies = _unitofwork.Movie.GetAll();

            List<MovieDTO> movieDTOs = new List<MovieDTO>();

            foreach (Movie movie in Movies)
            {
                movieDTOs.Add(new MovieDTO
                {
                    Id = movie.Id,
                    Title = movie.Title,
                    Director = movie.Director,
                    Duration = movie.Duration,
                    ReleaseYear = movie.ReleaseYear,
                    Rating = movie.Rating,
                    TicketPrice = movie.TicketPrice,
                    AvailableSeats = movie.AvailableSeats
                });
            }

            return Ok(movieDTOs);
        }

        [HttpGet("{id}")]
        public IActionResult GetById(int id)
        {
            var movie = _unitofwork.Movie.GetById(id);

            if (movie == null)
                return NotFound();

            MovieDTO movieDTO = new MovieDTO
            {
                Id = movie.Id,
                Title = movie.Title,
                Director = movie.Director,
                Duration = movie.Duration,
                ReleaseYear = movie.ReleaseYear,
                Rating = movie.Rating,
                TicketPrice = movie.TicketPrice,
                AvailableSeats = movie.AvailableSeats
            };

            return Ok(movieDTO);
        }

        [HttpPost]
        public IActionResult Add(CreateMovieDTO movieDTO)
        {
            Movie movie = new Movie
            {
                Title = movieDTO.Title,
                Director = movieDTO.Director,
                Duration = movieDTO.Duration,
                ReleaseYear = movieDTO.ReleaseYear,
                Rating = movieDTO.Rating,
                TicketPrice = movieDTO.TicketPrice,
                AvailableSeats = movieDTO.AvailableSeats,
                GenreId = movieDTO.GenreId
            };

            _unitofwork.Movie.Add(movie);
            _unitofwork.Save();

            return Created();
        }

        [HttpPut("{id}")]
        public IActionResult Update(int id, CreateMovieDTO movieDTO)
        {
            var movie = _unitofwork.Movie.GetById(id);

            if (movie == null)
                return NotFound();

            movie.Title = movieDTO.Title;
            movie.Director = movieDTO.Director;
            movie.Duration = movieDTO.Duration;
            movie.ReleaseYear = movieDTO.ReleaseYear;
            movie.Rating = movieDTO.Rating;
            movie.TicketPrice = movieDTO.TicketPrice;
            movie.AvailableSeats = movieDTO.AvailableSeats;
            movie.GenreId = movieDTO.GenreId;

            _unitofwork.Movie.Update(movie);
            _unitofwork.Save();

            return NoContent();
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            var movie = _unitofwork.Movie.GetById(id);
            _unitofwork.Movie.Delete(movie);
            _unitofwork.Save();

            return NoContent();
        }

        [HttpGet("search")]
        public IActionResult Search(string title)
        {
            var movie = _unitofwork.Movie.GetMovieByTitle(title);

            if (movie == null)
                return NotFound();

            MovieDTO movieDTO = new MovieDTO
            {
                Id = movie.Id,
                Title = movie.Title,
                Director = movie.Director,
                Duration = movie.Duration,
                ReleaseYear = movie.ReleaseYear,
                Rating = movie.Rating,
                TicketPrice = movie.TicketPrice,
                AvailableSeats = movie.AvailableSeats
            };

            return Ok(movieDTO);
        }
        [HttpGet("rating-greater-than/{rating}")]
        public IActionResult GetMoviesGreaterThanRating(int rating)
        {
            var Movies = _unitofwork.Movie.GetMoviesGreaterThanRating(rating);

            List<MovieDTO> movieDTOs = new List<MovieDTO>();

            foreach (Movie movie in Movies)
            {
                movieDTOs.Add(new MovieDTO
                {
                    Id = movie.Id,
                    Title = movie.Title,
                    Director = movie.Director,
                    Duration = movie.Duration,
                    ReleaseYear = movie.ReleaseYear,
                    Rating = movie.Rating,
                    TicketPrice = movie.TicketPrice,
                    AvailableSeats = movie.AvailableSeats,
                    GenreId = movie.GenreId
                });
            }

            return Ok(movieDTOs);
        }

        [HttpGet("price")]
        public IActionResult GetMoviesBetweenPrice(int min, int max)
        {
            var Movies = _unitofwork.Movie.GetMoviesBetweenPrice(min, max);

            List<MovieDTO> movieDTOs = new List<MovieDTO>();

            foreach (Movie movie in Movies)
            {
                movieDTOs.Add(new MovieDTO
                {
                    Id = movie.Id,
                    Title = movie.Title,
                    Director = movie.Director,
                    Duration = movie.Duration,
                    ReleaseYear = movie.ReleaseYear,
                    Rating = movie.Rating,
                    TicketPrice = movie.TicketPrice,
                    AvailableSeats = movie.AvailableSeats,
                    GenreId = movie.GenreId
                });
            }

            return Ok(movieDTOs);
        }

        [HttpGet("available")]
        public IActionResult GetAvailableMovies()
        {
            var Movies = _unitofwork.Movie.GetAvailableMovies();

            List<MovieDTO> movieDTOs = new List<MovieDTO>();

            foreach (Movie movie in Movies)
            {
                movieDTOs.Add(new MovieDTO
                {
                    Id = movie.Id,
                    Title = movie.Title,
                    Director = movie.Director,
                    Duration = movie.Duration,
                    ReleaseYear = movie.ReleaseYear,
                    Rating = movie.Rating,
                    TicketPrice = movie.TicketPrice,
                    AvailableSeats = movie.AvailableSeats,
                    GenreId = movie.GenreId
                });
            }

            return Ok(movieDTOs);
        }

        [HttpGet("top-rated")]
        public IActionResult GetTop5Movies()
        {
            var Movies = _unitofwork.Movie.GetTop5Movies();

            List<MovieDTO> movieDTOs = new List<MovieDTO>();

            foreach (Movie movie in Movies)
            {
                movieDTOs.Add(new MovieDTO
                {
                    Id = movie.Id,
                    Title = movie.Title,
                    Director = movie.Director,
                    Duration = movie.Duration,
                    ReleaseYear = movie.ReleaseYear,
                    Rating = movie.Rating,
                    TicketPrice = movie.TicketPrice,
                    AvailableSeats = movie.AvailableSeats,
                    GenreId = movie.GenreId
                });
            }

            return Ok(movieDTOs);
        }

        [HttpGet("latest")]
        public IActionResult GetLatestMovie()
        {
            var movie = _unitofwork.Movie.GetLatestMovie();

            if (movie == null)
                return NotFound();

            MovieDTO movieDTO = new MovieDTO
            {
                Id = movie.Id,
                Title = movie.Title,
                Director = movie.Director,
                Duration = movie.Duration,
                ReleaseYear = movie.ReleaseYear,
                Rating = movie.Rating,
                TicketPrice = movie.TicketPrice,
                AvailableSeats = movie.AvailableSeats,
                GenreId = movie.GenreId
            };

            return Ok(movieDTO);
        }

        [HttpGet("most-booked")]
        public IActionResult GetMostBookedMovie()
        {
            var movie = _unitofwork.Movie.GetMostBookedMovie();

            if (movie == null)
                return NotFound();

            MovieDTO movieDTO = new MovieDTO
            {
                Id = movie.Id,
                Title = movie.Title,
                Director = movie.Director,
                Duration = movie.Duration,
                ReleaseYear = movie.ReleaseYear,
                Rating = movie.Rating,
                TicketPrice = movie.TicketPrice,
                AvailableSeats = movie.AvailableSeats,
                GenreId = movie.GenreId
            };

            return Ok(movieDTO);
        }

        [HttpGet("count")]
        public IActionResult GetMoviesCount()
        {
            var count = _unitofwork.Movie.GetMoviesCount();

            return Ok(count);
        }

        [HttpGet("average-price")]
        public IActionResult GetAveragePrice()
        {
            var averagePrice = _unitofwork.Movie.GetAveragePriceTicket();

            return Ok(averagePrice);
        }

        [HttpGet("genre-details")]
        public IActionResult GetMoviesWithGenreDetails()
        {
            var Movies = _unitofwork.Movie.GetMoviesWithGenreDetails();
            var result = Movies.Select(movie => new
            {
                movie.Id,
                movie.Title,
                movie.Director,
                movie.Duration,
                movie.ReleaseYear,
                movie.Rating,
                movie.TicketPrice,
                movie.AvailableSeats,
                movie.GenreId,
                GenreName = movie.Genre.Name
            }).ToList();

            return Ok(result);
        }

        [HttpGet("paged")]
        public IActionResult GetMoviesPage(int pageNumber, int pageSize)
        {
            var Movies = _unitofwork.Movie.GetMoviesPage(pageNumber, pageSize);

            List<MovieDTO> movieDTOs = new List<MovieDTO>();

            foreach (Movie movie in Movies)
            {
                movieDTOs.Add(new MovieDTO
                {
                    Id = movie.Id,
                    Title = movie.Title,
                    Director = movie.Director,
                    Duration = movie.Duration,
                    ReleaseYear = movie.ReleaseYear,
                    Rating = movie.Rating,
                    TicketPrice = movie.TicketPrice,
                    AvailableSeats = movie.AvailableSeats,
                    GenreId = movie.GenreId
                });
            }

            return Ok(movieDTOs);
        }
    }
}

