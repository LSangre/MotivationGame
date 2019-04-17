using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace MotivationGame.DataLayer.Data
{
    public class ApplicationDbContext : IdentityDbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }
        public new DbSet<User> Users { get; set; }
        public DbSet<Game> Games { get; set; }
        public DbSet<Invitation> Invitations { get; set; }
    }
}
