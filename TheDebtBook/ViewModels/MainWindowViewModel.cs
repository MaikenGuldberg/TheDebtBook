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
        private INavigationService _navigationService;

        public MainWindowViewModel(DebtBookModel model, INavigationService navigationService)
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
        private ICommand _addDebitorCommand;


        public ICommand AddDeptToDebitorCommand
        {
            get
            {
                return _addDeptToDebitorCommand ?? (_addDeptToDebitorCommand = new DelegateCommand(() =>
          {
              _navigationService.ShowView(new AddDebtToDebitorViewModel(_model, _navigationService));
          }, () =>
          {
              return CurrentIndex >= 0;
          }
                       ).ObservesProperty(() => CurrentIndex));

            }
        }

        public ICommand AddDebitorCommand
        {
            get { return _addDebitorCommand ?? (_addDebitorCommand = new DelegateCommand(AddDebitor)); }
        }




        private void AddDebitor()
        {
            _navigationService.ShowView(new AddDebitorViewModel(_model, _navigationService));
        }

        

        #endregion
    }

    


}