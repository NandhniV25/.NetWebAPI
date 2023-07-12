using Microsoft.EntityFrameworkCore;
using World.API.Models;

namespace World.API.Data
{
    public class ApplicationDbContext : DbContext
    {
        //constructor ctor
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {
            
        }

        //create country table and configure
        public DbSet<Country> Countries { get; set; }
    }
}
