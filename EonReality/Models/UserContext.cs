using Microsoft.EntityFrameworkCore;

namespace EonReality.Models
{
    public class UserContext : DbContext
    {
        public UserContext(DbContextOptions<UserContext> options)
            : base(options)
        {
        }

        public DbSet<UserAPI> Users { get; set; }
    }
}
