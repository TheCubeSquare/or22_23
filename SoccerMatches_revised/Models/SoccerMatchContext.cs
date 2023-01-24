using Microsoft.EntityFrameworkCore;

namespace SoccerMatches_revised.Models
{
    public class SoccerMatchContext : DbContext
    {
        public SoccerMatchContext(DbContextOptions<SoccerMatchContext> options)
            : base(options)
        {
        }

        public DbSet<Match> match { get; set; }
        public DbSet<Player> Players { get; set; }
        public DbSet<Substitution> Substitutions { get; set; }
    }
}
