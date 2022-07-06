#pragma warning disable CS8618

using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
namespace GolfScorePoster.Models;

public class GolfContext : DbContext
{
    public GolfContext(DbContextOptions options) : base(options){  }

    public DbSet<GolfScore> Scores {get; set; }
    public DbSet<User> Users {get; set; }

    public DbSet<GolfCourse> Courses {get; set; }

    public DbSet<Association> Associations {get; set; }

}