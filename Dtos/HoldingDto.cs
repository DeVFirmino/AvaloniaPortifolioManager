namespace AvaloniaPortfolioManager.Dtos;

public record HoldingDto(
    int HoldingId,
    string Instrument,
    decimal Quantity,
    decimal MarketValue
);
