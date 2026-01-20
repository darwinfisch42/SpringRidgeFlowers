using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SpringRidgeFlowers.Data.Entities;

public class Stock
{
    [Key]
    public Guid Id { get; set; }

    public Guid PlantId { get; set; }

    [Column(TypeName = "jsonb")]
    public List<decimal> SeedPacketSizes { get; set; } = new();

    [Column(TypeName = "jsonb")]
    public List<int> PlantPotSizes { get; set; } = new();

    public int QuantityAvailable { get; set; }

    [NotMapped]
    public bool InStock => QuantityAvailable > 0;

    // Navigation
    public Plant Plant { get; set; } = null!;
}
