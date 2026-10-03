using System.ComponentModel.DataAnnotations;

namespace Assigment2.DTOs
{
    public class GenreDTO
    {
        [Key]
        public int Id { get; set; }
        [Required]
        [MaxLength(100)]
        public string Name { get; set; }
    }
}
