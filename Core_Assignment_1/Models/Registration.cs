using System.ComponentModel.DataAnnotations;

namespace Core_Assignment_1.Models
{
    public class Registration
    {
        [Key]
        public int ID { get; set; }
        public required string Name { get; set; }
        public required string Email { get; set; }
        public required string Password { get; set; }   
    }
}
