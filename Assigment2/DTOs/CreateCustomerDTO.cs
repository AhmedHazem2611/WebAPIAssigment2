using System.ComponentModel.DataAnnotations;

namespace Assigment2.DTOs
{
    public class CreateCustomerDTO
    {
        [Required]
        [MaxLength(150)]
        public string FullName { get; set; }
        [Required]
        [EmailAddress]
        public string Email { get; set; }
        [Phone]
        public string Phone { get; set; }
    }
}
