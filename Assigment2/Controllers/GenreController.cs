using Assigment2.DTOs;
using Assigment2.Models;
using Assigment2.Repos.Interface;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Assigment2.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class GenreController : ControllerBase
    {
        private readonly IUnitOfWork _unitOfWork;
        public GenreController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        [HttpGet]
        public IActionResult GetAll()
        {
            var Genres = _unitOfWork.Genre.GetAll();
            List<GenreDTO> genreDTOs = new List<GenreDTO>();
            foreach (var genre in Genres)
            {
                genreDTOs.Add(new GenreDTO
                {
                    Id = genre.Id,
                    Name = genre.Name
                });
            }
            return Ok(genreDTOs);
        }
        [HttpGet("{Id}")]
        public IActionResult GetById(int Id)
        {
            var Genre = _unitOfWork.Genre.GetById(Id);
            if (Genre == null)
                return BadRequest();
            GenreDTO genreDTO = new GenreDTO
            { 
                Id = Genre.Id,
                Name = Genre.Name
            };
            return Ok(genreDTO);
        }
        [HttpPost]
        public IActionResult AddGenre(CreateGenreDTO genreDTO)
        {
            Genre genre = new Genre
            {
                Name = genreDTO.Name
            };
            _unitOfWork.Genre.Add(genre);
            _unitOfWork.Save();
            return Created();
        }
        [HttpPut("{id}")]
        public IActionResult UpdateGenre(int id, CreateGenreDTO genre)
        {
            Genre genreold = _unitOfWork.Genre.GetById(id);
            genreold.Name = genre.Name;
            _unitOfWork.Genre.Update(genreold);
            _unitOfWork.Save();
            return Ok();
        }
        [HttpDelete]
        public IActionResult Delete(int id)
        {
            var Genre = _unitOfWork.Genre.GetById(id);
            _unitOfWork.Genre.Delete(Genre);
            _unitOfWork.Save();
            return Ok();
        }
        [HttpGet("movies")]
        public IActionResult GetByMovies()
        {
            var Genres = _unitOfWork.Genre.GetGenresMovies();
            var output = Genres.Select(Genre => new
            {
                id = Genre.Id,
                Name = Genre.Name,
                Movies = Genre.Movies.Select(movie => new
                {
                    MovieName = movie.Title,
                    Direction = movie.Director
                }
                )
            }
            );
            return Ok( output );

        }
       
    }
}
