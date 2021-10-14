using Microsoft.EntityFrameworkCore;

namespace Gym.Models
{
  public class GymContext : DbContext
  {
    public DbSet<Player> Players { get; set; }
    public DbSet<Activity> Activities { get; set; }
    public DbSet<ActivityPlayer> ActivityPlayer { get; set; }
    public DbSet<Amenity> Amenities {get;set;}
    public DbSet<Reservation> Reservations {get;set;}

    public GymContext(DbContextOptions options) : base(options) { }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
      optionsBuilder.UseLazyLoadingProxies();
    }
  }
}