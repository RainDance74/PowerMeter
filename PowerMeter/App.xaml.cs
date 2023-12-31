﻿using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.UI.Xaml;

using PowerMeter.Activation;
using PowerMeter.Contracts.Services;
using PowerMeter.Core.Contracts.Services;
using PowerMeter.Core.Services;
using PowerMeter.Helpers;
using PowerMeter.Models;
using PowerMeter.Services;
using PowerMeter.ViewModels;
using PowerMeter.ViewModels.Menu.Payments.PaymentsListViewModel;
using PowerMeter.ViewModels.Menu.Recommendations.Cards;
using PowerMeter.ViewModels.Menu.Users.Managing;
using PowerMeter.Views;
using PowerMeter.Views.Menu.Payments.PaymentHistory;
using PowerMeter.Views.Menu.Recommendations.Cards;
using PowerMeter.Views.Menu.Users.Managing;

namespace PowerMeter;

// To learn more about WinUI 3, see https://docs.microsoft.com/windows/apps/winui/winui3/.
public partial class App : Application
{
    // The .NET Generic Host provides dependency injection, configuration, logging, and other services.
    // https://docs.microsoft.com/dotnet/core/extensions/generic-host
    // https://docs.microsoft.com/dotnet/core/extensions/dependency-injection
    // https://docs.microsoft.com/dotnet/core/extensions/configuration
    // https://docs.microsoft.com/dotnet/core/extensions/logging
    public IHost Host
    {
        get;
    }

    public static T GetService<T>()
        where T : class
    {
        if ((App.Current as App)!.Host.Services.GetService(typeof(T)) is not T service)
        {
            throw new ArgumentException($"{typeof(T)} needs to be registered in ConfigureServices within App.xaml.cs.");
        }

        return service;
    }

    public static WindowEx MainWindow { get; } = new MainWindow();

    public static UIElement? AppTitlebar { get; set; }

    public App()
    {
        InitializeComponent();

        Host = Microsoft.Extensions.Hosting.Host.
        CreateDefaultBuilder().
        UseContentRoot(AppContext.BaseDirectory).
        ConfigureServices((context, services) =>
        {
            // Default Activation Handler
            services.AddTransient<ActivationHandler<LaunchActivatedEventArgs>, DefaultActivationHandler>();

            // Other Activation Handlers

            // Services
            services.AddSingleton<ILocalSettingsService, LocalSettingsService>();
            services.AddSingleton<IThemeSelectorService, ThemeSelectorService>();
            services.AddTransient<INavigationViewService, NavigationViewService>();

            services.AddSingleton<IActivationService, ActivationService>();
            services.AddSingleton<IPageService, PageService>();
            services.AddSingleton<INavigationService, NavigationService>();

            // Core Services
            // TODO: Change this👇 line after implement the real data
            services.AddSingleton<ISampleDataService, SampleDataService>();
            services.AddSingleton<IFileService, FileService>();

            // Views and ViewModels
            // TODO: Add lines with controls like that after adding new Views:
            // ShellPage
            services.AddTransient<ShellPage>();
            services.AddTransient<ShellViewModel>();
            // MainMenuPage
            services.AddTransient<MainMenuViewModel>();
            services.AddTransient<MainMenuPage>();
            // Users pages
            services.AddTransient<ViewModels.Menu.Users.UsersViewModel>();
            services.AddTransient<Views.Menu.Users.UsersPage>();

            services.AddTransient<ViewModels.Menu.Users.Cards.ContentGridDetailViewModel>();
            services.AddTransient<Views.Menu.Users.Cards.ContentGridDetailPage>();
            services.AddTransient<ViewModels.Menu.Users.Cards.ContentGridViewModel>();
            services.AddTransient<Views.Menu.Users.Cards.ContentGridPage>();

            services.AddTransient<DataGridViewModel>();
            services.AddTransient<DataGridPage>();
            // Recommendations pages
            services.AddTransient<ViewModels.Menu.Recommendations.RecommendationsViewModel>();
            services.AddTransient<Views.Menu.Recommendations.RecommendationsPage>();

            services.AddTransient<ViewModels.Menu.Recommendations.Cards.RecommendationsDetailViewModel>();
            services.AddTransient<Views.Menu.Recommendations.Cards.RecommendationsDetailPage>();

            services.AddTransient<ViewModels.Menu.Recommendations.Cards.RecommendationsViewModel>();
            services.AddTransient<Views.Menu.Recommendations.Cards.RecommendationsPage>();
            // Payments pages
            services.AddTransient<ViewModels.Menu.Payments.PaymentsViewModel>();
            services.AddTransient<Views.Menu.Payments.PaymentsPage>();

            services.AddTransient<ViewModels.Menu.Payments.PaymentsListViewModel.PaymentsListViewModel>();
            services.AddTransient<Views.Menu.Payments.PaymentHistory.PaymentsListPage>();
            // Chart page
            services.AddTransient<ChartViewModel>();
            services.AddTransient<ChartPage>();
            // Settings page
            services.AddTransient<SettingsViewModel>();
            services.AddTransient<SettingsPage>();

            // Configuration
            services.Configure<LocalSettingsOptions>(context.Configuration.GetSection(nameof(LocalSettingsOptions)));
        }).
        Build();

        UnhandledException += App_UnhandledException;
    }

    private void App_UnhandledException(object sender, Microsoft.UI.Xaml.UnhandledExceptionEventArgs e)
    {
        // TODO: Log and handle exceptions as appropriate.
        // https://docs.microsoft.com/windows/windows-app-sdk/api/winrt/microsoft.ui.xaml.application.unhandledexception.
    }

    protected async override void OnLaunched(LaunchActivatedEventArgs args)
    {
        base.OnLaunched(args);

        await App.GetService<IActivationService>().ActivateAsync(args);
    }
}
