using Microsoft.EntityFrameworkCore;
using TerraVision.API.Data;
using TerraVision.API.Models.Entities;
using TerraVision.API.Repositories.Interfaces;

namespace TerraVision.API.Repositories
{
    public class ClimateRepository : IClimateRepository
    {
        private readonly TerraVisionDbContext _context;

        public ClimateRepository(
            TerraVisionDbContext context)
        {
            _context = context;
        }

        public async Task SaveAsync(ClimateReading climate)
        {
            await _context.ClimateReadings.AddAsync(climate);

            await _context.SaveChangesAsync();
        }

        public async Task<List<ClimateReading>> GetAllAsync()
        {
            return await _context.ClimateReadings
                .OrderByDescending(c => c.ReadingDate)
                .ToListAsync();
        }

        public async Task<ClimateReading?> GetByIdAsync(Guid id)
        {
            return await _context.ClimateReadings
                .FirstOrDefaultAsync(c => c.Id == id);
        }
    }
}
