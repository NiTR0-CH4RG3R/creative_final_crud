using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace creative_final_crud.Models {
    public class BurrowRequest {
        
        [Key] 
        public int Id { get; set; }
        
        [Required]
        [ForeignKey("User")]
        public int UserId { get; set; }
        
        [Required]
        [ForeignKey("Book")]
        public int BookId { get; set; }
        
        [Required]
        public DateTime RequestedDate { get; set; } = DateTime.Now;

        [Required]
        public DateTime? ApprovedDate { get; set; } = null;

        [Required]
        public bool IsApproved { get; set; } = false;

        public User? User { get; set; } = null;
        public Book? Book { get; set; } = null;
    }
}