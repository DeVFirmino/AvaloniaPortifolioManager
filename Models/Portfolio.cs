using System.Collections.Generic;
using System.Linq;

namespace AvaloniaPortfolioManager.Models;

public class Portfolio
{
    
    public int PortfolioId { get; set; }

    public int ClientId { get; set; }

    public string Name { get; set; } = string.Empty;

    public string Currency { get; set; } = "EUR";

    public List<Holdings> Holdings { get; set; } = new();

    public List<PortfolioTransaction> Transactions { get; set; } = new();
    
    public decimal TotalMarketValue =>
        Holdings.Sum(h => h.MarketValue);

}