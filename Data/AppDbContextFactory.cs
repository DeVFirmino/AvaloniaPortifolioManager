using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;

namespace AvaloniaPortfolioManager.Data;

/// <summary>
/// Design-time factory used by the EF Core CLI (dotnet ef) to create the
/// DbContext without starting the Avalonia application.
/// </summary>
public class AppDbContextFactory : IDesignTimeDbContextFactory<AppDbContext>
{
    public AppDbContext CreateDbContext(string[] args)
    {
        var optionsBuilder = new DbContextOptionsBuilder<AppDbContext>();
        optionsBuilder.UseSqlite("Data Source=avalonia-portfolio.db");

        return new AppDbContext(optionsBuilder.Options);
    }
}