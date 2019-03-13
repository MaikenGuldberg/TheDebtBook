using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Markup;
using TheDebtBook.Annotations;
using TheDebtBook.ViewModels;

namespace TheDebtBook
{
    public class AddDebitorViewModel : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;

        [NotifyPropertyChangedInvocator]
        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        private DebtBookModel _model;

        public AddDebitorViewModel(DebtBookModel model)
        {
            _model = model;
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
                    //OnPropertyChanged();
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
                    //OnPropertyChanged();
                }
            }
        }

        private ICommand _addNewDebitorCommand;

        public ICommand AddNewDebitorCommand
        {
            get
            {
                return _addNewDebitorCommand ??
                       (_addNewDebitorCommand = new RelayCommand(AddNewDebitor, AddNewDebitorCanExecute));
            }
        }

        private void AddNewDebitor()
        {
            List<Debt> list = new List<Debt>();
        
            Debitor debitor = new Debitor(Name, list);
            debitor.Name = Name;
            Debt debt = new Debt(Value, DateTime.Now);
            debitor.Debts.Add(debt);
            _model.AddDebitor(debitor);
            //OnPropertyChanged();
        }

        private bool AddNewDebitorCanExecute()
        {
            bool paramsAreValid = (Name != null);
            return paramsAreValid;
        }


    }
}