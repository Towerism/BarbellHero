using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace BarbellHero.Repository {
  public class BarbellHeroDbContext : IdentityDbContext {
    public BarbellHeroDbContext(DbContextOptions options) : base(options) { }
  }
}