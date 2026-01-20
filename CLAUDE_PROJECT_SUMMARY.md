# SpringRidgeFlowers - Project Summary

## Overview
Blazor Web App for a home-based Florida flower/plant selling business. Uses MudBlazor UI and PostgreSQL.

## Tech Stack
- **.NET 8** (downgraded from .NET 9 due to EF tooling issues)
- **MudBlazor 8.5.0** - UI component library
- **Entity Framework Core 8.0.11** - ORM
- **Npgsql.EntityFrameworkCore.PostgreSQL 8.0.11** - PostgreSQL provider
- **PostgreSQL 16** - Database (via Docker)

## Project Structure
```
SpringRidgeFlowers/
├── Components/
│   ├── Layout/MainLayout.razor      # MudBlazor layout
│   ├── Pages/
│   │   ├── Home.razor               # Featured plants
│   │   ├── Catalog.razor            # Product grid + filters
│   │   └── PlantDetail.razor        # Individual plant page
│   ├── Shared/
│   │   ├── PlantCard.razor          # Product card
│   │   ├── PlantFilters.razor       # Filter sidebar
│   │   ├── PlantImageGallery.razor  # Image carousel
│   │   └── PriceDisplay.razor       # Formatted price
│   ├── App.razor
│   └── _Imports.razor
├── Data/
│   ├── Entities/                    # EF Core entities
│   │   ├── Plant.cs, PlantImage.cs, Stock.cs
│   │   ├── Category.cs, PlantCategory.cs
│   ├── ApplicationDbContext.cs
│   └── SeedData.cs                  # 6 sample Florida native plants
├── Services/
│   ├── Interfaces/IPlantService.cs
│   └── PlantService.cs              # Data access + filtering
├── Models/
│   ├── PlantDto.cs                  # View model
│   ├── PlantFilterModel.cs          # Filter/sort/pagination
│   └── PaginatedResult.cs           # Generic pagination
├── docker-compose.yml               # PostgreSQL container
├── Program.cs                       # Services + auto-migrate/seed
└── appsettings.Development.json     # Connection string
```

## Key Configuration

### PostgreSQL Connection (appsettings.Development.json)
```json
"ConnectionStrings": {
  "DefaultConnection": "Host=localhost;Port=5432;Database=springridgeflowers;Username=postgres;Password=postgres"
}
```

### Npgsql Dynamic JSON (Program.cs)
Required for JSONB columns in Stock entity:
```csharp
var dataSourceBuilder = new Npgsql.NpgsqlDataSourceBuilder(connectionString);
dataSourceBuilder.EnableDynamicJson();
var dataSource = dataSourceBuilder.Build();
```

## Commands
```bash
# Start PostgreSQL
docker-compose up -d

# EF Migrations (using local tool)
dotnet ef migrations add <Name>
dotnet ef database update

# Run app
dotnet run
```

## Known Issues & Fixes
1. **MudBlazor ValueChanged**: Don't use `@bind-Value` with `ValueChanged` - use `Value` + `ValueChanged` separately
2. **MudCarousel**: Requires `TData="object"` attribute
3. **Icons**: Use `Icons.Material.Filled.Grass` not `.Eco` (doesn't exist in 8.5.0)
4. **.NET 9 → 8**: Downgraded for EF tooling compatibility; use `href` paths not `Assets[]`

## Phase Status
- **Phase 1 (Catalog)**: COMPLETE - browsing, filtering, search, pagination
- **Phase 2 (Cart/Checkout)**: Not started
- **Phase 3 (Admin CRUD)**: Not started
- **Phase 4 (Stripe Payments)**: Not started

## Database Entities
- **Plant**: Core product with attributes (name, description, lifecycle, sun, water, native, edible, price)
- **PlantImage**: Multiple images per plant with display order
- **Stock**: Inventory with JSONB columns for seed/pot sizes
- **Category/PlantCategory**: Future categorization (join table)

## App URL
http://localhost:5274
