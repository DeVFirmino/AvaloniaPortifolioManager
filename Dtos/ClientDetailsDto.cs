using System.Collections.Generic;
using System.Linq;

namespace AvaloniaPortfolioManager.Dtos;

public record ClientDetailsDto(
    int ClientId,
    string FullName,
    string Country,
    List<PortfolioDto> Portfolios
)
{
    public int PortfolioCount => Portfolios.Count;

    public decimal TotalMarketValue =>
        Portfolios.Sum(p => p.TotalMarketValue);
}
