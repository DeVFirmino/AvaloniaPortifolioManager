using System;
using AvaloniaPortfolioManager.Models;
using Microsoft.EntityFrameworkCore;

namespace AvaloniaPortfolioManager.Data;

public class AppDbContext : DbContext
{
    public AppDbContext(DbContextOptions<AppDbContext> options)
        : base(options)
    {
    }

    public DbSet<Client> Clients => Set<Client>();
    public DbSet<Portfolio> Portfolios => Set<Portfolio>();
    public DbSet<Holdings> Holdings => Set<Holdings>();
    public DbSet<PortfolioTransaction> PortfolioTransactions => Set<PortfolioTransaction>();

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        ConfigureClients(modelBuilder);
        ConfigurePortfolios(modelBuilder);
        ConfigureHoldings(modelBuilder);
        ConfigurePortfolioTransactions(modelBuilder);
        SeedDemoData(modelBuilder);
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

    private static void SeedDemoData(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Client>().HasData(
            new Client { ClientId = 1, FullName = "Maria Borg", Country = "Malta", CreatedAt = new DateTime(2025, 11, 3) },
            new Client { ClientId = 2, FullName = "Karl Vella", Country = "Malta", CreatedAt = new DateTime(2025, 12, 18) },
            new Client { ClientId = 3, FullName = "Josef Camilleri", Country = "Malta", CreatedAt = new DateTime(2026, 1, 9) },
            new Client { ClientId = 4, FullName = "Claire Zammit", Country = "Malta", CreatedAt = new DateTime(2026, 2, 22) },
            new Client { ClientId = 5, FullName = "Matthew Micallef", Country = "Malta", CreatedAt = new DateTime(2026, 3, 14) },
            new Client { ClientId = 6, FullName = "Sarah Grech", Country = "Malta", CreatedAt = new DateTime(2026, 4, 6) },
            new Client { ClientId = 7, FullName = "David Attard", Country = "Malta", CreatedAt = new DateTime(2026, 5, 1) },
            new Client { ClientId = 8, FullName = "Elena Galea", Country = "Malta", CreatedAt = new DateTime(2026, 5, 27) });

        modelBuilder.Entity<Portfolio>().HasData(
            new Portfolio { PortfolioId = 1, ClientId = 1, Name = "Growth", Currency = "EUR" },
            new Portfolio { PortfolioId = 2, ClientId = 1, Name = "Income", Currency = "EUR" },
            new Portfolio { PortfolioId = 3, ClientId = 2, Name = "Retirement", Currency = "EUR" },
            new Portfolio { PortfolioId = 4, ClientId = 3, Name = "Growth", Currency = "EUR" },
            new Portfolio { PortfolioId = 5, ClientId = 4, Name = "Trading", Currency = "USD" },
            new Portfolio { PortfolioId = 6, ClientId = 5, Name = "Savings", Currency = "EUR" },
            new Portfolio { PortfolioId = 7, ClientId = 7, Name = "Balanced", Currency = "EUR" });

        modelBuilder.Entity<Holdings>().HasData(
            new Holdings { HoldingId = 1, PortfolioId = 1, Instrument = "AAPL", Quantity = 50, MarketValue = 12500m },
            new Holdings { HoldingId = 2, PortfolioId = 1, Instrument = "ETF-World", Quantity = 100, MarketValue = 9200m },
            new Holdings { HoldingId = 3, PortfolioId = 2, Instrument = "Bond-MGS", Quantity = 17, MarketValue = 17000m },
            new Holdings { HoldingId = 4, PortfolioId = 3, Instrument = "ETF-Global", Quantity = 220, MarketValue = 25300m },
            new Holdings { HoldingId = 5, PortfolioId = 3, Instrument = "Bond-MGS", Quantity = 10, MarketValue = 10000m },
            new Holdings { HoldingId = 6, PortfolioId = 4, Instrument = "MSFT", Quantity = 30, MarketValue = 13800m },
            new Holdings { HoldingId = 7, PortfolioId = 4, Instrument = "ETF-Europe", Quantity = 80, MarketValue = 6400m },
            new Holdings { HoldingId = 8, PortfolioId = 5, Instrument = "TSLA", Quantity = 25, MarketValue = 6100m },
            new Holdings { HoldingId = 9, PortfolioId = 5, Instrument = "NVDA", Quantity = 12, MarketValue = 14700m },
            new Holdings { HoldingId = 10, PortfolioId = 6, Instrument = "Bond-MGS", Quantity = 5, MarketValue = 5000m },
            new Holdings { HoldingId = 11, PortfolioId = 7, Instrument = "ETF-World", Quantity = 60, MarketValue = 5500m },
            new Holdings { HoldingId = 12, PortfolioId = 7, Instrument = "AAPL", Quantity = 10, MarketValue = 2500m });

        modelBuilder.Entity<PortfolioTransaction>().HasData(
            new PortfolioTransaction { PortfolioTransactionId = 1, PortfolioId = 1, Type = "BUY", Amount = 9500m, Date = new DateTime(2026, 5, 10) },
            new PortfolioTransaction { PortfolioTransactionId = 2, PortfolioId = 1, Type = "SELL", Amount = 1500m, Date = new DateTime(2026, 6, 20) },
            new PortfolioTransaction { PortfolioTransactionId = 3, PortfolioId = 2, Type = "BUY", Amount = 17000m, Date = new DateTime(2026, 4, 2) },
            new PortfolioTransaction { PortfolioTransactionId = 4, PortfolioId = 3, Type = "BUY", Amount = 20000m, Date = new DateTime(2026, 1, 15) },
            new PortfolioTransaction { PortfolioTransactionId = 5, PortfolioId = 3, Type = "BUY", Amount = 5300m, Date = new DateTime(2026, 3, 8) },
            new PortfolioTransaction { PortfolioTransactionId = 6, PortfolioId = 4, Type = "BUY", Amount = 14500m, Date = new DateTime(2026, 2, 11) },
            new PortfolioTransaction { PortfolioTransactionId = 7, PortfolioId = 5, Type = "BUY", Amount = 8200m, Date = new DateTime(2026, 5, 30) },
            new PortfolioTransaction { PortfolioTransactionId = 8, PortfolioId = 5, Type = "SELL", Amount = 2100m, Date = new DateTime(2026, 6, 25) },
            new PortfolioTransaction { PortfolioTransactionId = 9, PortfolioId = 6, Type = "BUY", Amount = 5000m, Date = new DateTime(2026, 3, 1) },
            new PortfolioTransaction { PortfolioTransactionId = 10, PortfolioId = 7, Type = "BUY", Amount = 8000m, Date = new DateTime(2026, 4, 18) });
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