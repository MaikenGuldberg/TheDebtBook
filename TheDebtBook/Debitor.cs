using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Windows.Documents;

namespace TheDebtBook
{
    public class Debitor
    {
        private string _name;
        private ObservableCollection<Debt> _debts;

        public Debitor(string name)
        {
            _name = name;
            _debts = new ObservableCollection<Debt>();
        }

        public Debitor(string name, ObservableCollection<Debt> debts)
        {
            _name = name;
            _debts = debts;
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
            get { return GetTotalDept(); }
        }

        private double GetTotalDept()
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
    }
}