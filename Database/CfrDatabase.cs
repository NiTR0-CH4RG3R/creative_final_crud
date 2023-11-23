using Microsoft.EntityFrameworkCore;

namespace creative_final_crud {
    public class CfrDatabase : DbContext {
        
        public CfrDatabase(DbContextOptions<CfrDatabase> options) : base(options) {
            
        }

        public DbSet<Models.User> User { get; set; }
        public DbSet<Models.Book> Book { get; set; }
        public DbSet<Models.BurrowRequest> BurrowRequest { get; set; }
    }
}