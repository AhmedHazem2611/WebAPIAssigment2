using System.ComponentModel.DataAnnotations;

namespace Assigment2.Models
{
    public class Genre
    {
        [Key]
        public int Id { get; set; }
        [Required]
        [MaxLength(100)]
        public string Name { get; set; }
        public List<Movie> Movies { get; set; } = new List<Movie>();
    }
}
