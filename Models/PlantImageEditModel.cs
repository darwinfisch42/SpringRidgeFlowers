namespace SpringRidgeFlowers.Models;

public class PlantImageEditModel
{
    public Guid Id { get; set; }
    public Guid PlantId { get; set; }
    public string ImageUrl { get; set; } = string.Empty;
    public string? AltText { get; set; }
    public int DisplayOrder { get; set; }
    public bool IsPrimary { get; set; }
}
