using Assigment2.DTOs;
using Assigment2.Models;
using Assigment2.Repos.Interface;
using Microsoft.AspNetCore.Mvc;

namespace Assigment2.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BookingController : ControllerBase
    {
        private readonly IUnitOfWork _unitofwork;

        public BookingController(IUnitOfWork unitofwork)
        {
            _unitofwork = unitofwork;
        }

        [HttpGet]
        public IActionResult GetAll()
        {
            var bookings = _unitofwork.Booking.GetAll();

            List<BookingDTO> bookingDTOs = new List<BookingDTO>();

            foreach (Booking booking in bookings)
            {
                bookingDTOs.Add(new BookingDTO
                {
                    Id = booking.Id,
                    BookingDate = booking.BookingDate,
                    NumberOfTickets = booking.NumberOfTickets,
                    TotalPrice = booking.TotalPrice,
                    CustomerId = booking.CustomerId,
                    MovieId = booking.MovieId
                });
            }

            return Ok(bookingDTOs);
        }

        [HttpGet("{id}")]
        public IActionResult GetById(int id)
        {
            var booking = _unitofwork.Booking.GetById(id);

            if (booking == null)
                return NotFound();

            BookingDTO bookingDTO = new BookingDTO
            {
                Id = booking.Id,
                BookingDate = booking.BookingDate,
                NumberOfTickets = booking.NumberOfTickets,
                TotalPrice = booking.TotalPrice,
                CustomerId = booking.CustomerId,
                MovieId = booking.MovieId
            };

            return Ok(bookingDTO);
        }

        [HttpPost]
        public IActionResult Book(CreateBookingDTO bookingDTO)
        {
            Booking booking = new Booking
            {
                NumberOfTickets = bookingDTO.NumberOfTickets,
                CustomerId = bookingDTO.CustomerId,
                MovieId = bookingDTO.MovieId
            };

            var Movie = _unitofwork.Movie.GetById(booking.MovieId);
            var Customer = _unitofwork.Customer.GetById(booking.CustomerId);
            if (Movie == null || Customer == null)
                return BadRequest();
            
            if (Movie.AvailableSeats < booking.NumberOfTickets)
                return BadRequest();

            booking.TotalPrice = (int)(Movie.TicketPrice * bookingDTO.NumberOfTickets);
            booking.BookingDate = DateTime.Now;
            Movie.AvailableSeats -= bookingDTO.NumberOfTickets;
            _unitofwork.Booking.Add(booking);
            _unitofwork.Save();
            return Created();

        }
        [HttpGet("details")]
        public IActionResult GetBookingDetails()
        {
            var bookings = _unitofwork.Booking.GetAllBookingsDetails();

            var result = bookings.Select(b => new
            {
                CustomerName = b.Customer.FullName,
                MovieTitle = b.Movie.Title,
                GenreName = b.Movie.Genre.Name,
                BookingDate = b.BookingDate,
                NumberOfTickets = b.NumberOfTickets,
                TotalPrice = b.TotalPrice
            }).ToList();

            return Ok(result);
        }
        [HttpGet("revenue")]
        public IActionResult GetRevenueReport()
        {
            var bookings = _unitofwork.Booking.GetRevenueReport();

            var result = bookings
                .GroupBy(b => new
                {
                    b.MovieId,
                    b.Movie.Title
                })
                .Select(g => new
                {
                    MovieId = g.Key.MovieId,
                    MovieTitle = g.Key.Title,
                    TotalTicketsSold = g.Sum(b => b.NumberOfTickets),
                    TotalRevenue = g.Sum(b => b.TotalPrice)
                })
                .OrderByDescending(x => x.TotalRevenue)
                .ToList();

            return Ok(result);
        }
    }
}