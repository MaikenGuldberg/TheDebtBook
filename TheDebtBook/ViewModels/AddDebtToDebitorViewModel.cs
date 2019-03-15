using System;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Windows.Input;
using Prism.Commands;
using TheDebtBook.Annotations;

namespace TheDebtBook
{
    public class AddDebtToDebitorViewModel:INotifyPropertyChanged
    {
        private DebtBookModel _model;
        private double _newDebt = 0;
        private INavigationService _navigationService;
        public AddDebtToDebitorViewModel(DebtBookModel model,INavigationService navigationService)
        {
            _model = model;
            _navigationService = navigationService;
        }

        public double NewDebt
        {
            get => _newDebt;
            set
            {
                if (value != _newDebt)
                {
                    _newDebt = value;
                    OnPropertyChanged();
                }
            }
        }

        public ObservableCollection<Debt> Debts
        {
            get
            {
                return _model.Debitors[_model.CurrentIndex].Debts;
            }
        }

        public string DebitorName
        {
            get { return _model.Debitors[_model.CurrentIndex].Name; }
        }

        public event PropertyChangedEventHandler PropertyChanged;

        [NotifyPropertyChangedInvocator]
        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        #region Commands

        private ICommand _addDebtCommand;

        public ICommand AddDebtCommand
        {
            get { return _addDebtCommand ?? (_addDebtCommand = new DelegateCommand(AddDebt)); }
        }

        private void AddDebt()
        {
            Debt debt = new Debt(_newDebt,DateTime.Now);
            _model.AddDeptToDebitor(debt,_model.CurrentIndex);
        }

        private ICommand _cancelCommand;

        public ICommand CancelCommand
        {
            get { return _cancelCommand ?? (_cancelCommand = new DelegateCommand(() =>
            {
                _navigationService.CloseView(this);
            })); }
        }



        #endregion
    }
}