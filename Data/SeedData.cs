using SpringRidgeFlowers.Data.Entities;

namespace SpringRidgeFlowers.Data;

public static class SeedData
{
    public static async Task InitializeAsync(ApplicationDbContext context)
    {
        if (context.Plants.Any())
            return;

        var plants = new List<Plant>
        {
            new()
            {
                Id = Guid.NewGuid(),
                CommonName = "Blanket Flower",
                LatinName = "Gaillardia pulchella",
                Description = "A vibrant Florida native wildflower with red and yellow daisy-like blooms. Extremely drought tolerant and attracts butterflies.",
                LifeCycle = "Annual",
                Size = "12-24 inches",
                SoilMoisture = "Dry to Medium",
                SunExposure = "Full Sun",
                IsFloridaNative = true,
                Price = 4.99m,
                Edible = false,
                WaterNeeds = "Low",
                ColdTolerance = "Zone 8-11",
                Images = new List<PlantImage>
                {
                    new() { Id = Guid.NewGuid(), ImageUrl = "/images/plants/blanket-flower.jpg", IsPrimary = true, DisplayOrder = 0, AltText = "Blanket Flower bloom" }
                },
                Stock = new Stock
                {
                    Id = Guid.NewGuid(),
                    QuantityAvailable = 50,
                    SeedPacketSizes = new List<decimal> { 0.5m, 1m, 2m },
                    PlantPotSizes = new List<int> { 4, 6 }
                }
            },
            new()
            {
                Id = Guid.NewGuid(),
                CommonName = "Coontie",
                LatinName = "Zamia integrifolia",
                Description = "Florida's only native cycad, an ancient palm-like plant. Host plant for the Atala butterfly. Very low maintenance once established.",
                LifeCycle = "Perennial",
                Size = "2-3 feet",
                SoilMoisture = "Dry to Medium",
                SunExposure = "Part Shade",
                IsFloridaNative = true,
                Price = 24.99m,
                Edible = false,
                WaterNeeds = "Low",
                ColdTolerance = "Zone 8-11",
                Images = new List<PlantImage>
                {
                    new() { Id = Guid.NewGuid(), ImageUrl = "/images/plants/coontie.jpg", IsPrimary = true, DisplayOrder = 0, AltText = "Coontie plant" }
                },
                Stock = new Stock
                {
                    Id = Guid.NewGuid(),
                    QuantityAvailable = 15,
                    SeedPacketSizes = new List<decimal>(),
                    PlantPotSizes = new List<int> { 6, 10 }
                }
            },
            new()
            {
                Id = Guid.NewGuid(),
                CommonName = "Firebush",
                LatinName = "Hamelia patens",
                Description = "Stunning native shrub with tubular orange-red flowers that bloom year-round. A hummingbird and butterfly magnet!",
                LifeCycle = "Perennial",
                Size = "6-12 feet",
                SoilMoisture = "Medium",
                SunExposure = "Full Sun",
                IsFloridaNative = true,
                Price = 12.99m,
                Edible = true,
                WaterNeeds = "Medium",
                ColdTolerance = "Zone 9-11",
                Images = new List<PlantImage>
                {
                    new() { Id = Guid.NewGuid(), ImageUrl = "/images/plants/firebush.jpg", IsPrimary = true, DisplayOrder = 0, AltText = "Firebush flowers" }
                },
                Stock = new Stock
                {
                    Id = Guid.NewGuid(),
                    QuantityAvailable = 25,
                    SeedPacketSizes = new List<decimal>(),
                    PlantPotSizes = new List<int> { 4, 6, 10 }
                }
            },
            new()
            {
                Id = Guid.NewGuid(),
                CommonName = "Tickseed",
                LatinName = "Coreopsis leavenworthii",
                Description = "Florida's state wildflower! Bright yellow blooms on delicate stems. Self-seeds readily and provides nectar for pollinators.",
                LifeCycle = "Annual",
                Size = "12-24 inches",
                SoilMoisture = "Medium to Wet",
                SunExposure = "Full Sun",
                IsFloridaNative = true,
                Price = 3.99m,
                Edible = false,
                WaterNeeds = "Medium",
                ColdTolerance = "Zone 8-11",
                Images = new List<PlantImage>
                {
                    new() { Id = Guid.NewGuid(), ImageUrl = "/images/plants/tickseed.jpg", IsPrimary = true, DisplayOrder = 0, AltText = "Tickseed yellow flowers" }
                },
                Stock = new Stock
                {
                    Id = Guid.NewGuid(),
                    QuantityAvailable = 100,
                    SeedPacketSizes = new List<decimal> { 0.5m, 1m, 5m },
                    PlantPotSizes = new List<int> { 4 }
                }
            },
            new()
            {
                Id = Guid.NewGuid(),
                CommonName = "Simpson's Stopper",
                LatinName = "Myrcianthes fragrans",
                Description = "Elegant native shrub with fragrant white flowers and edible orange berries. Excellent for hedges and wildlife gardens.",
                LifeCycle = "Perennial",
                Size = "6-20 feet",
                SoilMoisture = "Dry to Medium",
                SunExposure = "Part Shade",
                IsFloridaNative = true,
                Price = 18.99m,
                Edible = true,
                WaterNeeds = "Low",
                ColdTolerance = "Zone 9-11",
                Images = new List<PlantImage>
                {
                    new() { Id = Guid.NewGuid(), ImageUrl = "/images/plants/simpsons-stopper.jpg", IsPrimary = true, DisplayOrder = 0, AltText = "Simpson's Stopper berries" }
                },
                Stock = new Stock
                {
                    Id = Guid.NewGuid(),
                    QuantityAvailable = 8,
                    SeedPacketSizes = new List<decimal>(),
                    PlantPotSizes = new List<int> { 6, 10, 15 }
                }
            },
            new()
            {
                Id = Guid.NewGuid(),
                CommonName = "Blue Flag Iris",
                LatinName = "Iris virginica",
                Description = "Beautiful native iris with violet-blue flowers. Perfect for rain gardens, pond edges, and wet areas.",
                LifeCycle = "Perennial",
                Size = "2-3 feet",
                SoilMoisture = "Wet",
                SunExposure = "Full Sun",
                IsFloridaNative = true,
                Price = 9.99m,
                Edible = false,
                WaterNeeds = "High",
                ColdTolerance = "Zone 5-9",
                Images = new List<PlantImage>
                {
                    new() { Id = Guid.NewGuid(), ImageUrl = "/images/plants/blue-flag-iris.jpg", IsPrimary = true, DisplayOrder = 0, AltText = "Blue Flag Iris flower" }
                },
                Stock = new Stock
                {
                    Id = Guid.NewGuid(),
                    QuantityAvailable = 0,
                    SeedPacketSizes = new List<decimal>(),
                    PlantPotSizes = new List<int> { 4, 6 }
                }
            }
        };

        context.Plants.AddRange(plants);
        await context.SaveChangesAsync();
    }
}
