using Microsoft.EntityFrameworkCore;

namespace NotesAPI.Data
{
    public class ApplicationDbContext : DbContext
    {
        //Constructor
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {
            
        }
        public DbSet<Notes> Notes { get; set; }
    }
}
