using Microsoft.EntityFrameworkCore;
using Core.Models;

namespace AgrarianUa.AgrarianDbContextPath
{
    public class AgrarianDbContext : DbContext
    {

        public AgrarianDbContext(DbContextOptions<AgrarianDbContext> options) : base(options) { }

        public DbSet<Device> Devices { get; set; }

        public DbSet<Location> Locations { get; set; }

        public DbSet<Settings> Settings { get; set; }

        public DbSet<Schedule> Schedules { get; set; }
    }
}
