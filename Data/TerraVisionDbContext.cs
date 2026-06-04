using Microsoft.EntityFrameworkCore;
using TerraVision.API.Models.Entities;

namespace TerraVision.API.Data
{
    public class TerraVisionDbContext : DbContext
    {
        public TerraVisionDbContext(
            DbContextOptions<TerraVisionDbContext> options)
            : base(options)
        {
        }

        public DbSet<ClimateReading> ClimateReadings { get; set; }
    }
}
