namespace TheDebtBook
{
    public class ViewModelLocator
    {
        private DebtBookModel model = new DebtBookModel();
        private NavigationService navigationService = new NavigationService();

        public MainWindowViewModel MainViewModel
        {
            get { return new MainWindowViewModel(model, navigationService);}
        }

        public AddDebitorViewModel DebitorViewModel
        {
            get { return new AddDebitorViewModel(model);}
        }

        public AddDebtToDebitorViewModel DebtViewModel
        {
            get { return new AddDebtToDebitorViewModel(model);}
        }
    }
}