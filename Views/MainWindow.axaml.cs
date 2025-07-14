using Avalonia.Controls;
using LabUsage.ViewModels;
using System.Reactive;
using System.Net.Http;
using LabUsage.Services;
using System;

namespace LabUsage.Views;

public partial class MainWindow : Window
{
    public MainWindow()
    {
        var viewModel = new MainWindowViewModel();
        this.DataContext = viewModel;

        InitializeComponent();

        viewModel.ShowLoginInteraction.RegisterHandler(async interaction =>
        {
            var httpClient = new HttpClient();
            var loginService = new LoginService(httpClient);
            var loginWindow = new LoginView
            {
                DataContext = new LoginViewModel(loginService)
            };
            await loginWindow.ShowDialog(this);
            interaction.SetOutput(Unit.Default);
        });
    }
}