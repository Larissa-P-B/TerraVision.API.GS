using TerraVision.API.Models.Entities;

namespace TerraVision.API.Repositories.Interfaces
{
    public interface IClimateRepository
    {
        Task SaveAsync(ClimateReading climate);

        Task<List<ClimateReading>> GetAllAsync();

        Task<ClimateReading?> GetByIdAsync(Guid id);

        
    }
}
