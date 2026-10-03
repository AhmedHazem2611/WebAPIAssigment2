using Assigment2.Models;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Assigment2.DTOs
{
    public class CreateBookingDTO
    {
        [Required]
        [Range(1, int.MaxValue)]
        public int NumberOfTickets { get; set; }
        [Range(1, int.MaxValue)]
        [ForeignKey(nameof(CustomerId))]
        public int CustomerId { get; set; }
        [ForeignKey(nameof(MovieId))]
        public int MovieId { get; set; }
    }
}
