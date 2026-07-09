using Avalonia;
using Avalonia.Controls.ApplicationLifetimes;
using Avalonia.Markup.Xaml;
using AvaloniaPortfolioManager.Data;
using AvaloniaPortfolioManager.Services;
using AvaloniaPortfolioManager.ViewModels;
using AvaloniaPortfolioManager.Views;
using Microsoft.EntityFrameworkCore;

namespace AvaloniaPortfolioManager;

public partial class App : Application
{
    public override void Initialize()
    {
        AvaloniaXamlLoader.Load(this);
    }

    public override void OnFrameworkInitializationCompleted()
    {
        if (ApplicationLifetime is IClassicDesktopStyleApplicationLifetime desktop)
        {
            var options = new DbContextOptionsBuilder<AppDbContext>()
                .UseSqlite("Data Source=avalonia-portfolio.db")
                .Options;

            var dbContext = new AppDbContext(options);
            dbContext.Database.Migrate();

            var clientPortfolioService = new ClientPortfolioService(dbContext);

            desktop.MainWindow = new MainWindow
            {
                DataContext = new MainViewModel(clientPortfolioService),
            };
        }

        base.OnFrameworkInitializationCompleted();
    }
}
