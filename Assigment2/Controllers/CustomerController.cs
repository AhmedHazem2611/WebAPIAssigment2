using Assigment2.DTOs;
using Assigment2.Models;
using Assigment2.Repos.Interface;
using Microsoft.AspNetCore.Mvc;

namespace Assigment2.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CustomerController : ControllerBase
    {
        private readonly IUnitOfWork _unitofwork;

        public CustomerController(IUnitOfWork unitofwork)
        {
            _unitofwork = unitofwork;
        }

        [HttpGet]
        public IActionResult GetAll()
        {
            var Customers = _unitofwork.Customer.GetAll();

            List<CustomerDTO> customerDTOs = new List<CustomerDTO>();

            foreach (Customer customer in Customers)
            {
                customerDTOs.Add(new CustomerDTO
                {
                    Id = customer.Id,
                    FullName = customer.FullName,
                    Email = customer.Email,
                    Phone = customer.Phone
                });
            }

            return Ok(customerDTOs);
        }

        [HttpGet("{id}")]
        public IActionResult GetById(int id)
        {
            var customer = _unitofwork.Customer.GetById(id);

            if (customer == null)
                return NotFound();

            CustomerDTO customerDTO = new CustomerDTO
            {
                Id = customer.Id,
                FullName = customer.FullName,
                Email = customer.Email,
                Phone = customer.Phone
            };

            return Ok(customerDTO);
        }

        [HttpPost]
        public IActionResult Add(CreateCustomerDTO customerDTO)
        {
            Customer customer = new Customer
            {
                FullName = customerDTO.FullName,
                Email = customerDTO.Email,
                Phone = customerDTO.Phone
            };

            _unitofwork.Customer.Add(customer);
            _unitofwork.Save();

            CustomerDTO result = new CustomerDTO
            {
                Id = customer.Id,
                FullName = customer.FullName,
                Email = customer.Email,
                Phone = customer.Phone
            };

            return Created();
        }

        [HttpPut("{id}")]
        public IActionResult Update(int id, CustomerDTO customerDTO)
        {
            var customer = _unitofwork.Customer.GetById(id);

            if (customer == null)
                return NotFound();

            customer.FullName = customerDTO.FullName;
            customer.Email = customerDTO.Email;
            customer.Phone = customerDTO.Phone;

            _unitofwork.Customer.Update(customer);
            _unitofwork.Save();

            return NoContent();
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            var customer = _unitofwork.Customer.GetById(id);
            _unitofwork.Customer.Delete(customer);
            _unitofwork.Save();

            return NoContent();
        }
        [HttpGet("bookings")]
        public IActionResult GetCustomersWithBookings() 
        {
            var customers = _unitofwork.Customer.GetAllCustomersWithBooking();

            var result = customers.Select(customer => new
            {
                Id = customer.Id,
                FullName = customer.FullName,
                Email = customer.Email,
                Phone = customer.Phone,
                bookings = customer.Bookings.Select(booking => new
                {
                    BookingDate = booking.BookingDate,
                    NumberOfTickets = booking.NumberOfTickets,
                    TotalPrice = booking.TotalPrice
                }) 
            });

            return Ok(result);
        }
        [HttpGet("no-bookings")]
        public IActionResult GetCustomersWithNoBookings()
        {
            var customers = _unitofwork.Customer.GetCustomersWithNoBooking();
            List<CustomerDTO> customerDTOs = new List<CustomerDTO>();

            foreach (Customer customer in customers)
            {
                customerDTOs.Add(new CustomerDTO
                {
                    Id = customer.Id,
                    FullName = customer.FullName,
                    Email = customer.Email,
                    Phone = customer.Phone
                });
            }
            return Ok(customerDTOs);
        }

        [HttpGet("vip")]
        public IActionResult GetCustomersWithSpending()
        {
            var customers = _unitofwork.Customer.GetAllCustomersByTotalSpending();
            var result = customers.Select(customer => new
            {
                Id = customer.Id,
                FullName = customer.FullName,
                Email = customer.Email,
                Phone = customer.Phone,
                TotalPrice = customer.Bookings.Sum(booking => booking.TotalPrice)
            });
            return Ok(result);
        }
    }
}