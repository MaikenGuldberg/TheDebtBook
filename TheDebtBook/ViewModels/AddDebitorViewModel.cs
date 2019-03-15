using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Markup;
using Prism.Commands;
using TheDebtBook.Annotations;

namespace TheDebtBook
{
    public class AddDebitorViewModel : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;
        private INavigationService _navigationService;


        [NotifyPropertyChangedInvocator]
        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        private DebtBookModel _model;

        public AddDebitorViewModel(DebtBookModel model, INavigationService navigationService)
        {
            _model = model;
            _navigationService = navigationService;
        }

        private string _name;
        private double _value;

        public string Name
        {
            get => _name;
            set
            {
                if (value != _name)
                {
                    _name = value;
                    OnPropertyChanged();
                }
            }
        }

        public double Value
        {
            get => _value;
            set
            {
                if (value != _value)
                {
                    _value = value;
                    OnPropertyChanged();
                }
            }
        }

        private ICommand _addNewDebitorCommand;

        public ICommand AddNewDebitorCommand
        {
            get
            {
                return _addNewDebitorCommand ?? (_addNewDebitorCommand = new DelegateCommand(() =>
                           {
                               AddNewDebitor();

                           }, () =>
                           {
                               return Name != null;
                           }
                       ).ObservesProperty(() => Name));
            }
        }

        private void AddNewDebitor()
        {
            ObservableCollection<Debt> list = new ObservableCollection<Debt>();
        
            Debitor debitor = new Debitor(Name, list);
            debitor.Name = Name;
            Debt debt = new Debt(Value, DateTime.Now);
            debitor.Debts.Add(debt);
            _model.AddDebitor(debitor);
            
            AddDebitorViewModel addDebitorViewModel = new AddDebitorViewModel(_model, _navigationService);
            
            _navigationService.CloseView(this);
            //OnPropertyChanged();
        }

        private ICommand _cancelCommand;

        public ICommand CancelCommand
        {
            get { return _cancelCommand ?? (_cancelCommand = new DelegateCommand(() => { _navigationService.CloseView(this); })); }
        }

    }
}