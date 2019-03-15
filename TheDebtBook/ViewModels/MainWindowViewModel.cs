using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Dynamic;
using System.Runtime.CompilerServices;
using Prism.Mvvm;
using TheDebtBook.Annotations;
using Prism.Commands;
using System.Windows.Input;

namespace TheDebtBook
{
    public class MainWindowViewModel : BindableBase
    {

        private DebtBookModel _model;
        private int currentIndex;
        private NavigationService _navigationService;

        public MainWindowViewModel(DebtBookModel model, NavigationService navigationService)
        {
            _model = model;
            currentIndex = _model.CurrentIndex;
            _navigationService = navigationService;
        }

        public int CurrentIndex
        {
            get { return currentIndex; }
            set
            {
                SetProperty(ref currentIndex, value);
                _model.CurrentIndex = currentIndex;
            }
        }



        public ObservableCollection<Debitor> Debitors
        {
            get
            {
               return _model.Debitors;
            }
        }

        
        #region Commands
        ICommand _addDeptToDebitorCommand;
        private ICommand _addDepitorCommand;


        public ICommand AddDeptToDebitorCommand
        {
            get
            {
                return _addDeptToDebitorCommand ?? (_addDeptToDebitorCommand = new DelegateCommand(() =>
          {

          }, () =>
          {
              return CurrentIndex >= 0;
          }
                       ).ObservesProperty(() => CurrentIndex));

            }
        }

        public ICommand AddDepitorCommand
        {
            get { return _addDepitorCommand ?? (_addDepitorCommand = new DelegateCommand(AddDebitor)); }
        }




        private void AddDebitor()
        {
            AddDebitorViewModel addDebitorViewModel = new AddDebitorViewModel(_model, _navigationService);
            _navigationService.ShowView(addDebitorViewModel);
        }

        

        #endregion
    }

    


}