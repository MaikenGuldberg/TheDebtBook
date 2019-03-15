namespace TheDebtBook
{
    public class ViewModelLocator
    {
        private DebtBookModel model = new DebtBookModel();
        private NavigationService navigationService = new NavigationService();
        //private MainWindowViewModel _mainWindowViewModel;
        //private AddDebtToDebitorViewModel _addDebtToDebitorViewModel;
        //private AddDebitorViewModel _addDebitorViewModel;

        public MainWindowViewModel MainViewModel
        {
            get { return new MainWindowViewModel(model, navigationService);}
        }

        public AddDebitorViewModel DebitorViewModel
        {
            get { return new AddDebitorViewModel(model, navigationService);}
        }

        public AddDebtToDebitorViewModel DebtViewModel
        {
            get { return new AddDebtToDebitorViewModel(model);}
        }
    }
}