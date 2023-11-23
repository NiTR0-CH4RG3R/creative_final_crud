using System;

namespace creative_final_crud.Models {
    public class BurrowRequestDTO {
        public int Id { get; set; }
    
        public int UserId { get; set; }

        public int BookId { get; set; }

        public DateTime RequestedDate { get; set; } = DateTime.Now;

        public DateTime? ApprovedDate { get; set; } = null;

        public bool IsApproved { get; set; } = false;
    }
}