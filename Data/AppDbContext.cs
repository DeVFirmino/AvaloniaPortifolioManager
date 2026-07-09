using AvaloniaPortfolioManager.Models;
using Microsoft.EntityFrameworkCore;

namespace AvaloniaPortfolioManager.Data;

public class AppDbContext : DbContext
{
    public DbSet<Client> Clients => Set<Client>();
    public DbSet<Portfolio> Portfolios => Set<Portfolio>();
    public DbSet<Holdings> Holdings => Set<Holdings>();
    public DbSet<PortfolioTransaction> PortfolioTransactions => Set<PortfolioTransaction>();

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseSqlite("Data Source=avalonia-portfolio.db");
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        ConfigureClients(modelBuilder);
        ConfigurePortfolios(modelBuilder);
        ConfigureHoldings(modelBuilder);
        ConfigurePortfolioTransactions(modelBuilder);
    }

    private static void ConfigureClients(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Client>(entity =>
        {
            entity.HasKey(c => c.ClientId);

            entity.Property(c => c.FullName)
                .IsRequired()
                .HasMaxLength(100);

            entity.Property(c => c.Country)
                .HasMaxLength(50);

            entity.Property(c => c.CreatedAt)
                .IsRequired();

            entity.HasMany(c => c.Portfolios)
                .WithOne()
                .HasForeignKey(p => p.ClientId)
                .OnDelete(DeleteBehavior.Cascade);
        });
    }

    private static void ConfigurePortfolios(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Portfolio>(entity =>
        {
            entity.HasKey(p => p.PortfolioId);

            entity.Property(p => p.Name)
                .IsRequired()
                .HasMaxLength(100);

            entity.Property(p => p.Currency)
                .IsRequired()
                .HasMaxLength(3);

            entity.HasMany(p => p.Holdings)
                .WithOne()
                .HasForeignKey(h => h.PortfolioId)
                .OnDelete(DeleteBehavior.Cascade);

            entity.HasMany(p => p.Transactions)
                .WithOne()
                .HasForeignKey(t => t.PortfolioId)
                .OnDelete(DeleteBehavior.Cascade);
        });
        
    }

    private static void ConfigureHoldings(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Holdings>(entity =>
        {
            entity.HasKey(h => h.HoldingId);

            entity.Property(h => h.Instrument)
                .IsRequired()
                .HasMaxLength(50);

            entity.Property(h => h.Quantity)
                .HasPrecision(18, 4);

            entity.Property(h => h.MarketValue)
                .HasPrecision(18, 2);
        });
    }

    private static void ConfigurePortfolioTransactions(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<PortfolioTransaction>(entity =>
        {
            entity.HasKey(t => t.PortfolioTransactionId);

            entity.Property(t => t.Type)
                .IsRequired()
                .HasMaxLength(20);

            entity.Property(t => t.Amount)
                .HasPrecision(18, 2);

            entity.Property(t => t.Date)
                .IsRequired();

            entity.HasIndex(t => t.Date);

            entity.HasIndex(t => t.PortfolioId);
        });
    }
}