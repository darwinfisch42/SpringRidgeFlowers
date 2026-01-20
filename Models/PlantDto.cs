namespace SpringRidgeFlowers.Models;

public class PlantDto
{
    public Guid Id { get; set; }
    public string CommonName { get; set; } = string.Empty;
    public string? LatinName { get; set; }
    public string? Description { get; set; }
    public string? LifeCycle { get; set; }
    public string? Size { get; set; }
    public string? SoilMoisture { get; set; }
    public string? SunExposure { get; set; }
    public bool IsFloridaNative { get; set; }
    public decimal Price { get; set; }
    public bool Edible { get; set; }
    public string? WaterNeeds { get; set; }
    public string? ColdTolerance { get; set; }
    public string? PrimaryImageUrl { get; set; }
    public List<string> ImageUrls { get; set; } = new();
    public bool InStock { get; set; }
    public int QuantityAvailable { get; set; }
    public List<decimal> SeedPacketSizes { get; set; } = new();
    public List<int> PlantPotSizes { get; set; } = new();
}
