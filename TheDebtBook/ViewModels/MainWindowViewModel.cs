using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using TheDebtBook.Annotations;

namespace TheDebtBook
{
    public class MainWindowViewModel:INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;

        [NotifyPropertyChangedInvocator]
        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        private DebtBookModel _model;
        public MainWindowViewModel(DebtBookModel model)
        {
            _model = model;
        }

        public ObservableCollection<DebitorNameTotalDept> DebitorsNameTotalDepts
        {
            get
            {
                ObservableCollection<DebitorNameTotalDept> list = new ObservableCollection<DebitorNameTotalDept>();
                foreach (var d in _model.Debitors)
                {
                    DebitorNameTotalDept debitorNameTotal = new DebitorNameTotalDept();
                    debitorNameTotal.Name = d.Name;
                    debitorNameTotal.TotalDept = GetTotalDept(d);
                    list.Add(debitorNameTotal);
                }

                return list;
            }
        }

        private double GetTotalDept(Debitor d)
        {
            double totalDept = 0;
            foreach (var debt in d.Debts)
            {
                totalDept = +debt.Value;
            }

            return totalDept;
        }

    }

    public class DebitorNameTotalDept
    {
        public string Name { get; set; }
        public double TotalDept { get; set; }
    }
}