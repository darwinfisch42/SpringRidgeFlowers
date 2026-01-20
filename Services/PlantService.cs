using Microsoft.EntityFrameworkCore;
using SpringRidgeFlowers.Data;
using SpringRidgeFlowers.Data.Entities;
using SpringRidgeFlowers.Models;
using SpringRidgeFlowers.Services.Interfaces;

namespace SpringRidgeFlowers.Services;

public class PlantService : IPlantService
{
    private readonly ApplicationDbContext _context;

    public PlantService(ApplicationDbContext context)
    {
        _context = context;
    }

    public async Task<PaginatedResult<PlantDto>> GetPlantsAsync(PlantFilterModel filter)
    {
        var query = _context.Plants
            .Include(p => p.Images)
            .Include(p => p.Stock)
            .Where(p => p.IsActive)
            .AsQueryable();

        // Apply filters
        if (!string.IsNullOrWhiteSpace(filter.SearchTerm))
        {
            var term = filter.SearchTerm.ToLower();
            query = query.Where(p =>
                p.CommonName.ToLower().Contains(term) ||
                (p.LatinName != null && p.LatinName.ToLower().Contains(term)) ||
                (p.Description != null && p.Description.ToLower().Contains(term)));
        }

        if (filter.IsFloridaNative.HasValue)
            query = query.Where(p => p.IsFloridaNative == filter.IsFloridaNative.Value);

        if (filter.IsEdible.HasValue)
            query = query.Where(p => p.Edible == filter.IsEdible.Value);

        if (!string.IsNullOrWhiteSpace(filter.LifeCycle))
            query = query.Where(p => p.LifeCycle == filter.LifeCycle);

        if (!string.IsNullOrWhiteSpace(filter.SunExposure))
            query = query.Where(p => p.SunExposure == filter.SunExposure);

        if (!string.IsNullOrWhiteSpace(filter.WaterNeeds))
            query = query.Where(p => p.WaterNeeds == filter.WaterNeeds);

        if (filter.MinPrice.HasValue)
            query = query.Where(p => p.Price >= filter.MinPrice.Value);

        if (filter.MaxPrice.HasValue)
            query = query.Where(p => p.Price <= filter.MaxPrice.Value);

        if (filter.InStockOnly)
            query = query.Where(p => p.Stock != null && p.Stock.QuantityAvailable > 0);

        // Get total count before pagination
        var totalCount = await query.CountAsync();

        // Apply sorting
        query = filter.SortBy switch
        {
            "name_asc" => query.OrderBy(p => p.CommonName),
            "name_desc" => query.OrderByDescending(p => p.CommonName),
            "price_asc" => query.OrderBy(p => p.Price),
            "price_desc" => query.OrderByDescending(p => p.Price),
            "newest" => query.OrderByDescending(p => p.CreatedAt),
            _ => query.OrderBy(p => p.CommonName)
        };

        // Apply pagination
        var plants = await query
            .Skip((filter.Page - 1) * filter.PageSize)
            .Take(filter.PageSize)
            .ToListAsync();

        return new PaginatedResult<PlantDto>
        {
            Items = plants.Select(MapToDto).ToList(),
            TotalCount = totalCount,
            Page = filter.Page,
            PageSize = filter.PageSize
        };
    }

    public async Task<PlantDto?> GetPlantByIdAsync(Guid id)
    {
        var plant = await _context.Plants
            .Include(p => p.Images.OrderBy(i => i.DisplayOrder))
            .Include(p => p.Stock)
            .FirstOrDefaultAsync(p => p.Id == id && p.IsActive);

        return plant == null ? null : MapToDto(plant);
    }

    public async Task<List<PlantDto>> GetFeaturedPlantsAsync(int count = 6)
    {
        var plants = await _context.Plants
            .Include(p => p.Images)
            .Include(p => p.Stock)
            .Where(p => p.IsActive)
            .OrderByDescending(p => p.CreatedAt)
            .Take(count)
            .ToListAsync();

        return plants.Select(MapToDto).ToList();
    }

    public async Task<List<string>> GetDistinctLifeCyclesAsync()
    {
        return await _context.Plants
            .Where(p => p.IsActive && p.LifeCycle != null)
            .Select(p => p.LifeCycle!)
            .Distinct()
            .OrderBy(lc => lc)
            .ToListAsync();
    }

    public async Task<List<string>> GetDistinctSunExposuresAsync()
    {
        return await _context.Plants
            .Where(p => p.IsActive && p.SunExposure != null)
            .Select(p => p.SunExposure!)
            .Distinct()
            .OrderBy(se => se)
            .ToListAsync();
    }

    public async Task<List<string>> GetDistinctWaterNeedsAsync()
    {
        return await _context.Plants
            .Where(p => p.IsActive && p.WaterNeeds != null)
            .Select(p => p.WaterNeeds!)
            .Distinct()
            .OrderBy(wn => wn)
            .ToListAsync();
    }

    private static PlantDto MapToDto(Plant plant)
    {
        return new PlantDto
        {
            Id = plant.Id,
            CommonName = plant.CommonName,
            LatinName = plant.LatinName,
            Description = plant.Description,
            LifeCycle = plant.LifeCycle,
            Size = plant.Size,
            SoilMoisture = plant.SoilMoisture,
            SunExposure = plant.SunExposure,
            IsFloridaNative = plant.IsFloridaNative,
            Price = plant.Price,
            Edible = plant.Edible,
            WaterNeeds = plant.WaterNeeds,
            ColdTolerance = plant.ColdTolerance,
            PrimaryImageUrl = plant.Images.FirstOrDefault(i => i.IsPrimary)?.ImageUrl
                              ?? plant.Images.FirstOrDefault()?.ImageUrl,
            ImageUrls = plant.Images.OrderBy(i => i.DisplayOrder).Select(i => i.ImageUrl).ToList(),
            InStock = plant.Stock?.InStock ?? false,
            QuantityAvailable = plant.Stock?.QuantityAvailable ?? 0,
            SeedPacketSizes = plant.Stock?.SeedPacketSizes ?? new List<decimal>(),
            PlantPotSizes = plant.Stock?.PlantPotSizes ?? new List<int>()
        };
    }
}
