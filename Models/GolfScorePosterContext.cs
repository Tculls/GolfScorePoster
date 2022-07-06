#pragma warning disable CS8618

using Microsoft.EntityFrameworkCore;
namespace GolfScorePoster.Models;

public class ORMContext : DbContext
{
    public ORMContext(DbContextOptions options) : base(options){  }

    public DbSet<GolfScore> Scores {get; set; }
    public DbSet<User> Users {get; set; }
    
}