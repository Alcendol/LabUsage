using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using LabUsage.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LabUsage.ViewModels
{
    public partial class LoginViewModel : ViewModelBase
    {
        [ObservableProperty] private string _errorMessage = "";
        [ObservableProperty] private string _username = "";
        [ObservableProperty] private string _password = "";
        [ObservableProperty] private IReadOnlyList<DummyUser> _availableUsers = [];
        [ObservableProperty] private DummyUser? _selectedUser;

        partial void OnSelectedUserChanged(DummyUser? value)
        {
            if (value is null) return;
            Username = value.Username;
            Password = value.Password; 
        }

        private readonly ILoginService _loginService;

        public LoginViewModel(ILoginService loginService)
        {
            _loginService = loginService;
            _ = GetUsers();
        }

        [RelayCommand]
        private async Task Login()
        {
            var authResult = await _loginService.Authenticate(Username, Password);
            if (authResult is null)
            { 
                ErrorMessage = "Invalid username or password.";
                return;
            }
            ErrorMessage = "";
        }

        private async Task GetUsers()
        {
            AvailableUsers = await _loginService.Users();
        }
    }
}
