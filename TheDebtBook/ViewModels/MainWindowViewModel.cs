using System.Collections.ObjectModel;
using System.Collections.Specialized;
using System.ComponentModel;
using System.Dynamic;
using System.Runtime.CompilerServices;
using Prism.Mvvm;
using TheDebtBook.Annotations;
using Prism.Commands;
using System.Windows.Input;

namespace TheDebtBook
{
    public class MainWindowViewModel : INotifyPropertyChanged
    {

        private DebtBookModel _model;
        private INavigationService _navigationService;

        public MainWindowViewModel(DebtBookModel model, INavigationService navigationService)
        {
            _model = model;
            _navigationService = navigationService;
        }

        public int CurrentIndex
        {
            get { return _model.CurrentIndex; }
            set
            {
                if (value != _model.CurrentIndex)
                {
                    _model.CurrentIndex = value;
                    OnPropertyChanged();
                }
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

        private ICommand _addDebitorCommand;

        public ICommand AddDebitorCommand
        {
            get { return _addDebitorCommand ?? (_addDebitorCommand = new DelegateCommand(AddDebitor)); }
        }

        private void AddDebitor()
        {
            _navigationService.ShowView(new AddDebitorViewModel(_model, _navigationService));
        }

        private ICommand _deleteDebitorCommand;

        public ICommand DeleteDebitorCommand
        {
            get { return _deleteDebitorCommand ?? (_deleteDebitorCommand = new DelegateCommand((() =>
            {
                _model.RemoveDebitor();
            }),(() => { return CurrentIndex >= 0; })).ObservesProperty((() => CurrentIndex))); }
        }


        #endregion

        public event PropertyChangedEventHandler PropertyChanged;

        [NotifyPropertyChangedInvocator]
        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }

    


}