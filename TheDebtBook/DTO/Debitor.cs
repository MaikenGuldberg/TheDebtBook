using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Windows.Documents;
using TheDebtBook.Annotations;

namespace TheDebtBook
{
    public class Debitor : INotifyPropertyChanged
    {
        private string _name;
        private ObservableCollection<Debt> _debts;
        private double _totalDebt;

        public Debitor(string name)
        {
            _name = name;
            _debts = new ObservableCollection<Debt>();
            _totalDebt = GetTotalDept();
        }

        public Debitor(string name, ObservableCollection<Debt> debts)
        {
            _name = name;
            _debts = debts;
            _totalDebt = GetTotalDept();
        }

        public string Name
        {
            get => _name;
            set => _name = value;
        }

        public ObservableCollection<Debt> Debts
        {
            get => _debts;
            set => _debts = value;
        }
        public double TotalDebt
        {
            get { return _totalDebt; }
            set
            {
                if (_totalDebt != value)
                {
                    _totalDebt = value;
                    OnPropertyChanged();
                }
                
            }
        }

        public double GetTotalDept()
        {
            double totalDept = 0;
            if (_debts.Count > 0)
            {
                
                foreach (var debt in _debts)
                {
                    totalDept = totalDept + debt.Value;
                }
            }
            return totalDept;
        }

        public event PropertyChangedEventHandler PropertyChanged;

        [NotifyPropertyChangedInvocator]
        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}