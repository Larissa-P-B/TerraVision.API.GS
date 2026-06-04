using TerraVision.API.Models.DTOs;
using TerraVision.API.Models.Entities;

namespace TerraVision.API.Services.Interfaces
{
    public interface IClimateService
    {
        Task<ClimateResponseDto> GetClimateAsync(string city);

        Task<List<ClimateReading>> GetHistoryAsync();

        Task<ClimateReading?> GetByIdAsync(Guid id);

        Task<ClimateStatsDto> GetStatsAsync();
    }
}
