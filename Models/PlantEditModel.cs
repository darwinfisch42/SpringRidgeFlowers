using System.ComponentModel.DataAnnotations;

namespace SpringRidgeFlowers.Models;

public class PlantEditModel
{
    public Guid? Id { get; set; }

    [Required(ErrorMessage = "Common name is required")]
    [MaxLength(200, ErrorMessage = "Common name cannot exceed 200 characters")]
    public string CommonName { get; set; } = string.Empty;

    [MaxLength(200, ErrorMessage = "Latin name cannot exceed 200 characters")]
    public string? LatinName { get; set; }

    [MaxLength(4000, ErrorMessage = "Description cannot exceed 4000 characters")]
    public string? Description { get; set; }

    [MaxLength(50)]
    public string? LifeCycle { get; set; }

    [MaxLength(100, ErrorMessage = "Size cannot exceed 100 characters")]
    public string? Size { get; set; }

    [MaxLength(50)]
    public string? SoilMoisture { get; set; }

    [MaxLength(50)]
    public string? SunExposure { get; set; }

    public bool IsFloridaNative { get; set; }

    [Range(0.01, 9999.99, ErrorMessage = "Price must be between $0.01 and $9,999.99")]
    public decimal Price { get; set; }

    public bool Edible { get; set; }

    [MaxLength(50)]
    public string? WaterNeeds { get; set; }

    [MaxLength(50)]
    public string? ColdTolerance { get; set; }

    public bool IsActive { get; set; } = true;

    // Inventory
    [Range(0, int.MaxValue, ErrorMessage = "Quantity must be 0 or greater")]
    public int QuantityAvailable { get; set; }

    public string? PrimaryImageUrl { get; set; }
}
