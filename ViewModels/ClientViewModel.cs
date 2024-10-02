using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.CompilerServices;
using WPF_MVVM_SPA_Template.Models;
using WPF_MVVM_SPA_Template.Views;

namespace WPF_MVVM_SPA_Template.ViewModels
{
    class ClientViewModel : INotifyPropertyChanged
    {
        private readonly MainViewModel _mainViewModel;
        public ObservableCollection<Client> Clients { get; set; } = new ObservableCollection<Client>();

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
        private Client? _editableClient;
        public Client? EditableClient
        {
            get { return _editableClient; }
            set { _editableClient = value; OnPropertyChanged() ; }
    }
        public RelayCommand AddClientCommand { get; set; }
        public RelayCommand DelClientCommand { get; set; }
        public RelayCommand EditClientCommand { get; set; }
        public RelayCommand CancelCommand { get; set; }
        public RelayCommand SaveCommand { get; set; }

        public ClientViewModel(MainViewModel mainViewModel)
        {
            _mainViewModel = mainViewModel;
            // Carreguem estudiants a memòria mode de prova
            Clients.Add(new Client { Code = "C001", Name = "David", DniNif = "12345678A", Profesional = true, Discount = 10, RegistrationDate = DateTime.Now, TotalAnualSells = 1500.00 });
            Clients.Add(new Client { Code = "C002", Name = "Jordi", DniNif = "87654321B", Profesional = false, Discount = 5, RegistrationDate = DateTime.Now, TotalAnualSells = 1200.00 });
            // Inicialitzem els diferents commands disponibles (accions)
            AddClientCommand = new RelayCommand(x => AddClient());
            DelClientCommand = new RelayCommand(x => DelClient());
            EditClientCommand = new RelayCommand(x => EditClient(), x => SelectedClient != null);
            SaveCommand = new RelayCommand(x => SaveClient(), x => EditableClient != null);
            CancelCommand = new RelayCommand(x => CancelEdit());

        }
        private void EditClient()
        {
            if (SelectedClient != null)
            {
                EditableClient = new Client
                {
                    Code = SelectedClient.Code,
                    Name = SelectedClient.Name,
                    DniNif = SelectedClient.DniNif,
                    Profesional = SelectedClient.Profesional,
                    RegistrationDate = SelectedClient.RegistrationDate,
                    Discount = SelectedClient.Discount,
                    TotalAnualSells = SelectedClient.TotalAnualSells
                };
                _mainViewModel.CurrentView = new EditarUsuari { DataContext = this };
            }
        }
        private void SaveClient()
{
    
            SelectedClient.Code = EditableClient.Code;
            SelectedClient.Name = EditableClient.Name;
            SelectedClient.DniNif = EditableClient.DniNif;
            SelectedClient.Profesional = EditableClient.Profesional;
            SelectedClient.Discount = EditableClient.Discount;
            SelectedClient.RegistrationDate = EditableClient.RegistrationDate;
            SelectedClient.TotalAnualSells = EditableClient.TotalAnualSells;
            SelectedClient = null;
                

            _mainViewModel.CurrentView = new ClientsView { DataContext = this };
            
        }


        private void CancelEdit()
        {
            _mainViewModel.CurrentView = new ClientsView { DataContext = this };
            SelectedClient = null;

        }
        private void AddClient()
        {
            Clients.Add(new Client { Code = "C002", Name = "Jordi", DniNif = "87654321B", Profesional = false, Discount = 5, RegistrationDate = DateTime.Now, TotalAnualSells = 1200 });
            _mainViewModel.CurrentView = new ClientsView { DataContext = this };
        }

        private void DelClient()
        {
            if (SelectedClient != null)
                Clients.Remove(SelectedClient);
        }
        
    }
       

}
