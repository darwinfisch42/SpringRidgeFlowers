using System.ComponentModel.DataAnnotations;

namespace SpringRidgeFlowers.Data.Entities;

public class Category
{
    [Key]
    public Guid Id { get; set; }

    [Required]
    [MaxLength(100)]
    public string Name { get; set; } = string.Empty;

    [MaxLength(500)]
    public string? Description { get; set; }

    [MaxLength(100)]
    public string Slug { get; set; } = string.Empty;

    public int DisplayOrder { get; set; }

    public bool IsActive { get; set; } = true;

    // Navigation
    public ICollection<PlantCategory> PlantCategories { get; set; } = new List<PlantCategory>();
}

public class PlantCategory
{
    public Guid PlantId { get; set; }
    public Plant Plant { get; set; } = null!;

    public Guid CategoryId { get; set; }
    public Category Category { get; set; } = null!;
}
