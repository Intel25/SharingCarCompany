using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using VirtualCarHustler.Models;

namespace VirtualCarHustler
{
    public class DataContext : IdentityDbContext
    {
        private readonly IConfiguration configuration;
        public DataContext(IConfiguration config)
        {
            configuration = config;
        }
        protected override void OnConfiguring(DbContextOptionsBuilder options)
        {
            options.UseSqlServer(configuration.GetConnectionString("DefaultConnection"));
        }
        public DbSet<VehicleModel> Vehicles { get; set; }

    }
}
