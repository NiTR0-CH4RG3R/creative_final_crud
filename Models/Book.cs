using System.ComponentModel.DataAnnotations;

namespace creative_final_crud.Models {
    public class Book {
        [Key]
        public int Id { get; set; }

        [Required]
        public string? Title { get; set; }

        [Required]
        public string? Author { get; set; }

        [Required]
        public int Qty { get; set; } = 0;
    }
}