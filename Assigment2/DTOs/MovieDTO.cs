using System.ComponentModel.DataAnnotations;

namespace Assigment2.DTOs
{
    public class MovieDTO
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [MaxLength(100)]
        public string Title { get; set; }
        [Required]
        [MaxLength(200)]
        public string Director { get; set; }
        [Range(30, 300)]
        [Required]
        public int Duration { get; set; }
        [Required]
        [Range(1950, 2026)]
        public int ReleaseYear { get; set; }
        [Required]
        [Range(0, 10)]
        public int Rating { get; set; }
        [Range(1, double.MaxValue)]
        [Required]
        public decimal TicketPrice { get; set; }
        [Required]
        [Range(0, int.MaxValue)]
        public int AvailableSeats { get; set; }
        public int GenreId { get; set; }
    }
}
