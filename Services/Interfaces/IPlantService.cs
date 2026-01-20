using SpringRidgeFlowers.Models;

namespace SpringRidgeFlowers.Services.Interfaces;

public interface IPlantService
{
    Task<PaginatedResult<PlantDto>> GetPlantsAsync(PlantFilterModel filter);
    Task<PlantDto?> GetPlantByIdAsync(Guid id);
    Task<List<PlantDto>> GetFeaturedPlantsAsync(int count = 6);
    Task<List<string>> GetDistinctLifeCyclesAsync();
    Task<List<string>> GetDistinctSunExposuresAsync();
    Task<List<string>> GetDistinctWaterNeedsAsync();
}
