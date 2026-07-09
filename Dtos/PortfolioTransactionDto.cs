using System;

namespace AvaloniaPortfolioManager.Dtos;

public record PortfolioTransactionDto(
    int PortfolioTransactionId,
    string Type,
    decimal Amount,
    DateTime Date
);
