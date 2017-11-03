using Microsoft.EntityFrameworkCore;

namespace splunge-cookie.Models
{
    public class BrightContext : DbContext
    {
        public BrightContext(DbContextOptions<BrightContext> options) : base(options) { }
        public DbSet<User> Users { get; set; }
        public DbSet<Idea> Ideas { get; set; }
        public DbSet<Like> Likes { get; set; }
    }
}