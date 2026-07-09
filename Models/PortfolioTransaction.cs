using System;

namespace AvaloniaPortfolioManager.Models;

public class PortfolioTransaction
{
    public int PortfolioTransactionId { get; set; }

    public int PortfolioId { get; set; }

    public string Type { get; set; } = string.Empty;

    public decimal Amount { get; set; }

    public DateTime Date { get; set; } = DateTime.UtcNow;
}