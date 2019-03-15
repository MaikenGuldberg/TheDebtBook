namespace TheDebtBook
{
    public class ViewModelLocator
    {
        private DebtBookModel _model;

        private NavigationService _navigationService;
        //private MainWindowViewModel _mainWindowViewModel;
        //private AddDebtToDebitorViewModel _addDebtToDebitorViewModel;
        //private AddDebitorViewModel _addDebitorViewModel;

        public ViewModelLocator()
        {
            _model = new DebtBookModel();
            _navigationService = new NavigationService();
        }

        public MainWindowViewModel MainViewModel
        {
            get { return new MainWindowViewModel(_model, _navigationService);}
        }
    }
}