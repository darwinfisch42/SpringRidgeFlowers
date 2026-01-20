using System.ComponentModel.DataAnnotations;

namespace SpringRidgeFlowers.Data.Entities;

public class PlantImage
{
    [Key]
    public Guid Id { get; set; }

    public Guid PlantId { get; set; }

    [Required]
    [MaxLength(500)]
    public string ImageUrl { get; set; } = string.Empty;

    [MaxLength(200)]
    public string? AltText { get; set; }

    public int DisplayOrder { get; set; }

    public bool IsPrimary { get; set; }

    // Navigation
    public Plant Plant { get; set; } = null!;
}
