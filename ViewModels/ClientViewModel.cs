using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.CompilerServices;
using WPF_MVVM_SPA_Template.Models;

namespace WPF_MVVM_SPA_Template.ViewModels
{
    class ClientViewModel : INotifyPropertyChanged
    {
        private readonly MainViewModel _mainViewModel;
        public ObservableCollection<Client>Clients{ get; set; } = new ObservableCollection<Client>();

        private Client? _selectedClient;

        public event PropertyChangedEventHandler? PropertyChanged;

        protected void OnPropertyChanged([CallerMemberName] string? name = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));
        }

        public Client? SelectedClient
        {
            get { return _selectedClient; }
            set { _selectedClient = value; OnPropertyChanged(); }
        }
        public RelayCommand AddClientCommand { get; set; }
        public RelayCommand DelClientCommand { get; set; }

        public ClientViewModel(MainViewModel mainViewModel)
        {
            _mainViewModel = mainViewModel;
            // Carreguem estudiants a memòria mode de prova
            Clients.Add(new Client { Code = "C001", Name = "David", DniNif = "12345678A", Profesional = true, Discount = 10, RegistrationDate = DateTime.Now, TotalAnualSells = 1500.00 });
            Clients.Add(new Client { Code = "C002", Name = "Jordi", DniNif = "87654321B", Profesional = false, Discount = 5, RegistrationDate = DateTime.Now, TotalAnualSells = 1200.00 });
            // Inicialitzem els diferents commands disponibles (accions)
            AddClientCommand = new RelayCommand(x => AddClient());
            DelClientCommand = new RelayCommand(x => DelClient());
        }
        private void AddClient()
        {
            Clients.Add(new Client { Code = "C002", Name = "Jordi", DniNif = "87654321B", Profesional = false, Discount = 5, RegistrationDate = DateTime.Now, TotalAnualSells = 1200 });
        }

        private void DelClient()
        {
            if (SelectedClient != null)
                Clients.Remove(SelectedClient);
        }
        
    }
       

}
