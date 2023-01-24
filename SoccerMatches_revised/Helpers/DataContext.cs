using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using SoccerMatches_revised.Entities;

namespace SoccerMatches_revised.Helpers
{
    public class DataContext : DbContext
    {
        protected readonly IConfiguration Configuration;

        public DataContext(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        protected override void OnConfiguring(DbContextOptionsBuilder options)
        {
            options.UseNpgsql(Configuration.GetConnectionString("SoccerMatches"));
        }

        public DbSet<User> Users { get; set; }
    }
}
