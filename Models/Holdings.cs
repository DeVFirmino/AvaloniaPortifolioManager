namespace AvaloniaPortfolioManager.Models;

public class Holdings
{
    public int HoldingId { get; set; }

    public int PortfolioId { get; set; }

    public string Instrument { get; set; } = string.Empty;

    public decimal Quantity { get; set; }

    public decimal MarketValue { get; set; }
}
