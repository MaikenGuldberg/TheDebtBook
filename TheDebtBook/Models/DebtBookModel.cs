using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;

namespace TheDebtBook
{
    public class DebtBookModel
    {
        private ObservableCollection<Debitor> _debitors;
        public int CurrentIndex { set; get; }

        public DebtBookModel()
        {
            _debitors = new ObservableCollection<Debitor>()
            {
              #if DEBUG
              new Debitor("Nicklas",new ObservableCollection<Debt>(){new Debt(50,DateTime.Now),new Debt(-10,DateTime.Now),new Debt(20,DateTime.Now)}),
              new Debitor("Mikkel",new ObservableCollection<Debt>(){new Debt(200,DateTime.Now),new Debt(30,DateTime.Now),new Debt(-100,DateTime.Now)})
              #endif
            };
            CurrentIndex = -1;
        }

        public void AddDebitor(Debitor d)
        {
            _debitors.Add(d);
        }

        public void RemoveDebitor()
        {
            _debitors.RemoveAt(CurrentIndex);
        }

        public void AddDeptToDebitor(Debt debt)
        {
            _debitors[CurrentIndex].Debts.Add(debt);
            _debitors[CurrentIndex].TotalDebt = _debitors[CurrentIndex].GetTotalDept();
        }

        public void DeleteDebt(int index)
        {
            _debitors[CurrentIndex].TotalDebt =
                _debitors[CurrentIndex].GetTotalDept() - _debitors[CurrentIndex].Debts[index].Value;
            _debitors[CurrentIndex].Debts.RemoveAt(index);
        }

        public ObservableCollection<Debitor> Debitors => _debitors;
    }
}