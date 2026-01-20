using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SpringRidgeFlowers.Data.Entities;

public class Plant
{
    [Key]
    public Guid Id { get; set; }

    [Required]
    [MaxLength(200)]
    public string CommonName { get; set; } = string.Empty;

    [MaxLength(200)]
    public string? LatinName { get; set; }

    [MaxLength(4000)]
    public string? Description { get; set; }

    [MaxLength(50)]
    public string? LifeCycle { get; set; }

    [MaxLength(100)]
    public string? Size { get; set; }

    [MaxLength(50)]
    public string? SoilMoisture { get; set; }

    [MaxLength(50)]
    public string? SunExposure { get; set; }

    public bool IsFloridaNative { get; set; }

    [Column(TypeName = "decimal(10,2)")]
    public decimal Price { get; set; }

    public bool Edible { get; set; }

    [MaxLength(50)]
    public string? WaterNeeds { get; set; }

    [MaxLength(50)]
    public string? ColdTolerance { get; set; }

    public bool IsActive { get; set; } = true;

    public DateTime CreatedAt { get; set; } = DateTime.UtcNow;

    public DateTime? UpdatedAt { get; set; }

    // Navigation properties
    public ICollection<PlantImage> Images { get; set; } = new List<PlantImage>();
    public Stock? Stock { get; set; }
    public ICollection<PlantCategory> PlantCategories { get; set; } = new List<PlantCategory>();
}
