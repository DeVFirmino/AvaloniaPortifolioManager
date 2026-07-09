using System;
using System.Collections.Generic;
using System.Linq;

namespace AvaloniaPortfolioManager.Models;

public class Client
{
    public int ClientId { get; set; }

    public string FullName { get; set; } = string.Empty;

    public string Country { get; set; } = string.Empty;

    public DateTime CreatedAt { get; set; } = DateTime.UtcNow;

    public List<Portfolio> Portfolios { get; set; } = new();

    public int PortfolioCount => Portfolios.Count;

    // public decimal TotalMarketValue =>
    //     Portfolios.Sum(p => p.TotalMarketValue);
}