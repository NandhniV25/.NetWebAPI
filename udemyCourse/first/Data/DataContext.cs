
namespace first.Data
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> options) : base(options) 
        {
            
        }
        public DbSet<Characters> Characters => Set<Characters>();
        public DbSet<User> Users => Set<User>();
    }
}
