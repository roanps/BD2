using Microsoft.EntityFrameworkCore;
using Greenhouse.Models;

namespace Greenhouse.Data
{
    public class GreenhouseContext : DbContext
    {
        public GreenhouseContext(DbContextOptions<GreenhouseContext> options)
            : base(options)
        {
        }

        public DbSet<Plant> Plants { get; set; }
    }
}
