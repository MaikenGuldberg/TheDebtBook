using System;
using System.Collections.ObjectModel;

namespace TheDebtBook
{
    public class AddDebtToDebitorViewModel
    {
        private DebtBookModel _model;
        public AddDebtToDebitorViewModel(DebtBookModel model)
        {
            _model = model;
        }

        public ObservableCollection<Debt> DebtsDatesValues
        {
            get
            {
                ObservableCollection<DebtDateValue> list = new ObservableCollection<DebtDateValue>();
                foreach (var debt in _model.Debitors[_model.CurrentIndex].Debts)
                {
                    DebtDateValue debtDateValue = new DebtDateValue();
                    debtDateValue.Date = debt.Date.ToString("MM/dd/yyyy");
                    debtDateValue.Value = debt.Value;
                }

                return _model.Debitors[_model.CurrentIndex].Debts;
            }
        }
    }

    public class DebtDateValue
    {
        public string Date { get; set; }
        public double Value { get; set; }
    }
}