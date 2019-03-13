namespace TheDebtBook
{
    public class ViewModelLocator
    {
        private DebtBookModel model = new DebtBookModel();

        public MainWindowViewModel MainViewModel
        {
            get { return new MainWindowViewModel(model);}
        }

        public AddDebitorViewModel DebitorViewModel
        {
            get { return new AddDebitorViewModel(model);}
        }
    }
}