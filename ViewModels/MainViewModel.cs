using System.ComponentModel;
using System.Runtime.CompilerServices;
using WPF_MVVM_SPA_Template.Views;

namespace WPF_MVVM_SPA_Template.ViewModels
{
    //Els ViewModels deriven de INotifyPropertyChanged per poder fer Binding de propietats
    class MainViewModel : INotifyPropertyChanged
    {

        // ViewModels de les diferents opcions
      
        public ClientViewModel ClientVM { get; set; }
        public FacturaViewModel FacturaVM { get; set; }

        // Propietat que conté la vista actual (és un objecte)
        private object? _currentView;
        public object? CurrentView
        {
            get { return _currentView; }
            set { _currentView = value; OnPropertyChanged(); }
        }

        // Propietat per controlar la vista seleccionada al ListBox (És un string)
        private string? _selectedView;
        public string? SelectedView
        {
            get { return _selectedView; }
            set
            {
                _selectedView = value;
                OnPropertyChanged();
                ChangeView();
            }
        }

        public MainViewModel()
        {
            // Inicialitzem els diferents ViewModels
            ClientVM = new ClientViewModel(this);
            FacturaVM = new FacturaViewModel(this);
            // Mostra la vista principal inicialment
            SelectedView = "Clients";
            ChangeView();
        }

        // Canvi de Vista
        private void ChangeView()
        {
            switch (SelectedView)
            {
                case "Clients": CurrentView = new ClientsView { DataContext = ClientVM }; break;
                case "Factures": CurrentView = new FacturesView { DataContext = FacturaVM }; break;
            }
        }

        // Això és essencial per fer funcionar el Binding de propietats entre Vistes i ViewModels
        public event PropertyChangedEventHandler? PropertyChanged;
        protected void OnPropertyChanged([CallerMemberName] string? name = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));
        }
    }
}
