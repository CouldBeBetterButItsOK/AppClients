﻿using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.CompilerServices;
using WPF_MVVM_SPA_Template.Models;
using WPF_MVVM_SPA_Template.Views;
using System.Diagnostics.Eventing.Reader;
using System.Windows;
using System.Net.Mail;
using System.Xml.Linq;
using System.Text.RegularExpressions;

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
            set { _editableClient = value; OnPropertyChanged(); }
        }
        public RelayCommand AddClientCommand { get; set; }
        public RelayCommand DelClientCommand { get; set; }
        public RelayCommand EditClientCommand { get; set; }
        public RelayCommand CancelCommand { get; set; }
        public RelayCommand SaveCommand { get; set; }
        public RelayCommand OKCommand { get; set; }

        public ClientViewModel(MainViewModel mainViewModel)
        {
            _mainViewModel = mainViewModel;
            // Carreguem estudiants a memòria mode de prova
            Clients.Add(new Client { Code = "C001", Name = "David", DniNif = "12345678A", Profesional = true, Discount = 10, RegistrationDate = DateTime.Now, TotalAnualSells = 1500.00, Tel = "654321432", Mail = "david@uvic.cat", MailAddress = new MailAddress("david@uvic.cat","David") });
            Clients.Add(new Client { Code = "C002", Name = "Jordi", DniNif = "87654321B", Profesional = false, Discount = 5, RegistrationDate = DateTime.Now, TotalAnualSells = 1200.00, Tel = "654321431", Mail = "jordi@uvic.cat", MailAddress = new MailAddress("jordi@uvic.cat", "Jordi") });
            // Inicialitzem els diferents commands disponibles (accions)
            AddClientCommand = new RelayCommand(x => AddClient());
            DelClientCommand = new RelayCommand(x => DelClient());
            EditClientCommand = new RelayCommand(x => EditClient(), x => SelectedClient != null);
            SaveCommand = new RelayCommand(x => SaveClient(), x => EditableClient != null);
            CancelCommand = new RelayCommand(x => CancelEdit());
            OKCommand = new RelayCommand(x => OKError());

        }
        private void EditClient()
        {
            if (SelectedClient != null)
            {
                EditableClient = new Client();
                EditableClient.cloneClient(SelectedClient);
                _mainViewModel.CurrentView = new EditarUsuari { DataContext = this };
            }
        }
        private void SaveClient() {
            if (ClientCheck(EditableClient)) {
                if (SelectedClient != null)
                {
                    SelectedClient.cloneClient(EditableClient);
                    SelectedClient = null;
                }
                else { Clients.Add(new Client(EditableClient));
                }
                _mainViewModel.CurrentView = new ClientsView { DataContext = this };
            }
        }


        private void CancelEdit()
        {
            _mainViewModel.CurrentView = new ClientsView { DataContext = this };
            SelectedClient = null;

        }
        private void AddClient()
        {
            SelectedClient = null;
            EditableClient = new Client();
            EditableClient.Code = "C" + (Clients.Count + 1).ToString("D3");
            EditableClient.RegistrationDate = DateTime.Now;
            _mainViewModel.CurrentView = new EditarUsuari { DataContext = this };
        }

        private void DelClient()
        {
            if (SelectedClient != null)
                Clients.Remove(SelectedClient);
        }
        public Boolean ClientCheck(Client client){
            Regex EmailRegex = new Regex(
            @"^[^@\s]+@[^@\s]+\.[^@\s]+$",
            RegexOptions.IgnoreCase);
            string error = "";
            if(client.Name.Length >= 3)
            {
                if (client.DniNif.Length >= 3)
                {
                    if (int.TryParse(client.Tel, out int result) & client.Tel.Length == 9)
                    {
                        if (EmailRegex.IsMatch(client.Mail))
                        {
                            return true;
                        }
                        else error = "Correu elèctronic incorrecte";
                    }
                    else error = "Número de telèfon incorrecte";
                }
                else error = "El DNI no és vàlid";
            }
            else error = "El nom no és vàlid";
            ShowError(error);
            return false;
        }    
        private void ShowError(String error)
        {
            _mainViewModel.CurrentView = new CustomMessageBox(error) { DataContext = this };
        }
        private void OKError()
        {
            _mainViewModel.CurrentView = new EditarUsuari { DataContext = this };
        }
    }
       

}
