using System;
using System.Collections.ObjectModel;
using System.Threading.Tasks;
using AvaloniaPortfolioManager.Dtos;
using AvaloniaPortfolioManager.Services;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;

namespace AvaloniaPortfolioManager.ViewModels;

public partial class MainViewModel : ViewModelBase
{
    private readonly IClientPortfolioService _clientPortfolioService;

    public MainViewModel(IClientPortfolioService clientPortfolioService)
    {
        _clientPortfolioService = clientPortfolioService;
    }

    public ObservableCollection<ClientSummaryDto> Clients { get; } = new();

    [ObservableProperty]
    private ClientSummaryDto? _selectedClient;

    [ObservableProperty]
    private ClientDetailsDto? _selectedClientDetails;

    [ObservableProperty]
    private string _searchText = string.Empty;

    [ObservableProperty]
    private string _statusMessage = "Ready";

    [RelayCommand]
    private async Task LoadClientsAsync()
    {
        try
        {
            StatusMessage = "Loading clients...";

            var clients = await _clientPortfolioService.GetClientSummariesAsync(SearchText);

            Clients.Clear();
            foreach (var client in clients)
            {
                Clients.Add(client);
            }

            StatusMessage = $"{Clients.Count} clients loaded";
        }
        catch (Exception ex)
        {
            StatusMessage = $"Error loading clients: {ex.Message}";
        }
    }

    [RelayCommand]
    private async Task ClearSearchAsync()
    {
        SearchText = string.Empty;
        await LoadClientsAsync();
    }

    partial void OnSelectedClientChanged(ClientSummaryDto? value)
    {
        _ = LoadClientDetailsAsync(value);
    }

    private async Task LoadClientDetailsAsync(ClientSummaryDto? selectedClient)
    {
        if (selectedClient == null)
        {
            SelectedClientDetails = null;
            return;
        }

        try
        {
            SelectedClientDetails =
                await _clientPortfolioService.GetClientDetailsAsync(selectedClient.ClientId);
        }
        catch (Exception ex)
        {
            StatusMessage = $"Error loading client details: {ex.Message}";
        }
    }
}
