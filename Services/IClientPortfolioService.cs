using System.Collections.Generic;
using System.Threading.Tasks;
using AvaloniaPortfolioManager.Dtos;

namespace AvaloniaPortfolioManager.Services;

public interface IClientPortfolioService
{
    Task<List<ClientSummaryDto>> GetClientSummariesAsync(string? searchText = null);

    Task<ClientDetailsDto?> GetClientDetailsAsync(int clientId);
}
