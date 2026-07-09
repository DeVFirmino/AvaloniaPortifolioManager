using System.Collections.Generic;
using System.Linq;

namespace AvaloniaPortfolioManager.Dtos;

public record PortfolioDto(
    int PortfolioId,
    string Name,
    string Currency,
    List<HoldingDto> Holdings,
    List<PortfolioTransactionDto> Transactions
)
{
    public decimal TotalMarketValue =>
        Holdings.Sum(h => h.MarketValue);
}
