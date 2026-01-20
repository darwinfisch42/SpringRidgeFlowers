namespace SpringRidgeFlowers.Models;

public class PlantFilterModel
{
    public string? SearchTerm { get; set; }
    public bool? IsFloridaNative { get; set; }
    public bool? IsEdible { get; set; }
    public string? LifeCycle { get; set; }
    public string? SunExposure { get; set; }
    public string? WaterNeeds { get; set; }
    public decimal? MinPrice { get; set; }
    public decimal? MaxPrice { get; set; }
    public bool InStockOnly { get; set; }
    public string SortBy { get; set; } = "name_asc";
    public int Page { get; set; } = 1;
    public int PageSize { get; set; } = 12;
}
