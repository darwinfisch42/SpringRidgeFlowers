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

    // Admin CRUD operations
    Task<List<PlantDto>> GetAllPlantsForAdminAsync();
    Task<PlantEditModel?> GetPlantForEditAsync(Guid id);
    Task<Guid> CreatePlantAsync(PlantEditModel model);
    Task UpdatePlantAsync(PlantEditModel model);
    Task DeletePlantAsync(Guid id);

    // Image management
    Task<List<PlantImageEditModel>> GetPlantImagesAsync(Guid plantId);
    Task<PlantImageEditModel> AddPlantImageAsync(Guid plantId, string imageUrl, string? altText);
    Task DeletePlantImageAsync(Guid imageId);
    Task SetPrimaryImageAsync(Guid plantId, Guid imageId);
}
