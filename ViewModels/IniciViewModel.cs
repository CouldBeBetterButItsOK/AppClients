using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Net.Sockets;
using System.Net;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace WPF_MVVM_SPA_Template.ViewModels
{
    class IniciViewModel : INotifyPropertyChanged
    {
        private readonly string _mainViewModel;
        public IniciViewModel(MainViewModel mainViewModel) { }
        public event PropertyChangedEventHandler? PropertyChanged;
        protected void OnPropertyChanged([CallerMemberName] string? name = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));
        }
        public RelayCommand LightThemeCommand { get; set; }
        public RelayCommand DarkThemeCommand { get; set; }
        

    }
}
