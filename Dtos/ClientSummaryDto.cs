namespace AvaloniaPortfolioManager.Dtos;

public record ClientSummaryDto(
    int ClientId,
    string FullName,
    string Country,
    int PortfolioCount,
    decimal TotalMarketValue
);
