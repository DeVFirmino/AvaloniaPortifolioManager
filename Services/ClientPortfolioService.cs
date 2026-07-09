using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AvaloniaPortfolioManager.Data;
using AvaloniaPortfolioManager.Dtos;
using Microsoft.EntityFrameworkCore;

namespace AvaloniaPortfolioManager.Services;

public class ClientPortfolioService : IClientPortfolioService
{
    private readonly AppDbContext _db;

    public ClientPortfolioService(AppDbContext db)
    {
        _db = db;
    }

    public async Task<List<ClientSummaryDto>> GetClientSummariesAsync(string? searchText = null)
    {
        var clients = await _db.Clients
            .Include(c => c.Portfolios)
            .ThenInclude(p => p.Holdings)
            .ToListAsync();

        if (!string.IsNullOrWhiteSpace(searchText))
        {
            clients = clients
                .Where(c => c.FullName.ToLower().Contains(searchText.ToLower()) ||
                            c.Country.ToLower().Contains(searchText.ToLower()))
                .ToList();
        }

        return clients
            .OrderBy(c => c.FullName)
            .Select(c => new ClientSummaryDto(
                c.ClientId,
                c.FullName,
                c.Country,
                c.Portfolios.Count,
                c.Portfolios.Sum(p => p.Holdings.Sum(h => h.MarketValue))))
            .ToList();
    }

    public async Task<ClientDetailsDto?> GetClientDetailsAsync(int clientId)
    {
        var client = await _db.Clients
            .Include(c => c.Portfolios)
                .ThenInclude(p => p.Holdings)
            .Include(c => c.Portfolios)
                .ThenInclude(p => p.Transactions)
            .FirstOrDefaultAsync(c => c.ClientId == clientId);

        if (client == null)
        {
            return null;
        }

        var portfolios = client.Portfolios
            .Select(p => new PortfolioDto(
                p.PortfolioId,
                p.Name,
                p.Currency,
                p.Holdings
                    .Select(h => new HoldingDto(
                        h.HoldingId,
                        h.Instrument,
                        h.Quantity,
                        h.MarketValue))
                    .ToList(),
                p.Transactions
                    .OrderByDescending(t => t.Date)
                    .Select(t => new PortfolioTransactionDto(
                        t.PortfolioTransactionId,
                        t.Type,
                        t.Amount,
                        t.Date))
                    .ToList()))
            .ToList();

        return new ClientDetailsDto(
            client.ClientId,
            client.FullName,
            client.Country,
            portfolios);
    }
}
