using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using WPF_MVVM_SPA_Template.Models;

namespace WPF_MVVM_SPA_Template.ViewModels
{
    class FacturaViewModel : INotifyPropertyChanged
    {
        private readonly MainViewModel _mainViewModel;
        public ObservableCollection<Factura> Factures { get; set; } = new ObservableCollection<Factura>();

        private Factura? _selectedFactura;

        public event PropertyChangedEventHandler? PropertyChanged;

        protected void OnPropertyChanged([CallerMemberName] string? name = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));
        }

        public Factura? SelectedFactura
        {
            get { return _selectedFactura; }
            set { _selectedFactura = value; OnPropertyChanged(); }
        }
        public RelayCommand AddFacturaCommand { get; set; }
        public RelayCommand DelFacturaCommand { get; set; }

        public FacturaViewModel(MainViewModel mainViewModel)
        {
            _mainViewModel = mainViewModel;
            // Inicialitzem els diferents commands disponibles (accions)
            AddFacturaCommand = new RelayCommand(x => AddFactura());
            DelFacturaCommand = new RelayCommand(x => DelFactura());
        }
        private void AddFactura()
        {
        }

        private void DelFactura()
        {
            if (SelectedFactura != null)
                Factures.Remove(SelectedFactura);
        }

    }


}
