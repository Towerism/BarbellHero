using BarbellHero.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace BarbellHero.Repositories
{
    public class BarbellHeroDbContext : IdentityDbContext
    {
        public BarbellHeroDbContext(DbContextOptions options) : base(options) { }

        public DbSet<Movement> Movements { get; set; }
    }
}