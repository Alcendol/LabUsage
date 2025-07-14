using CommunityToolkit.Mvvm.ComponentModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LabUsage.ViewModels
{
    public partial class SecretViewModel : ViewModelBase
    {
        [ObservableProperty] private string _token;

        public SecretViewModel(string authResult)
        {
            _token = authResult;
        }
    }
}
