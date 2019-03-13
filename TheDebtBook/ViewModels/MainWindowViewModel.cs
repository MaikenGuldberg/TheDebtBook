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
    public class MainWindowViewModel:BindableBase
    {

        private DebtBookModel _model;
        private int currentIndex;
        public MainWindowViewModel(DebtBookModel model)
        {
            _model = model;
            currentIndex = _model.CurrentIndex;
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
                totalDept = totalDept + debt.Value;
            }

            return totalDept;
        }
        #region Commands
        ICommand _addDeptToDebitorCommand;

        public ICommand AddDeptToDebitorCommand
        {
            get { return _addDeptToDebitorCommand ?? (_addDeptToDebitorCommand = new DelegateCommand(() =>
            {

            }, () => {
                                 return CurrentIndex >= 0;
                             }
                         ).ObservesProperty(() => CurrentIndex));

            }
        }

        #endregion
    }

    public class DebitorNameTotalDept
    {
        public string Name { get; set; }
        public double TotalDept { get; set; }
    }

    
}