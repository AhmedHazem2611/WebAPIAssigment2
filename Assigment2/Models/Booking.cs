using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
namespace Assigment2.Models
{
    public class Booking
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public DateTime BookingDate { get; set; }
        [Required]
        [Range(1, int.MaxValue)]
        public int NumberOfTickets { get; set; }
        [Range(1, int.MaxValue)]
        [Required]
        public int TotalPrice { get; set; }
        [ForeignKey(nameof(CustomerId))]
        public int CustomerId { get; set; }
        public Customer Customer { get; set; }
        [ForeignKey(nameof(MovieId))]
        public int MovieId { get; set; }
        public Movie Movie { get; set; } 
    }
}
