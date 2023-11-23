using System.ComponentModel.DataAnnotations;

namespace creative_final_crud.Models
{
    public class User
    {
        [Key]
        public int Id { get; set; }
        
        [Required]
        public string? Name { get; set; } = null;
        
        [Required]
        public string? Email { get; set; } = null;
        
        [Required]
        public string? Password { get; set; } = null;
        
        [Required]
        public bool IsAdmin { get; set; } = false;
    }
}