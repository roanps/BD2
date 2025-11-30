using Microsoft.EntityFrameworkCore;
using Floricultura.Models;

namespace Floricultura.Data
{
    public class FloriculturaContext : DbContext
    {
        public FloriculturaContext(DbContextOptions<FloriculturaContext> options)
            : base(options) { }

        public DbSet<Plant> Plants { get; set; }
    }
}
