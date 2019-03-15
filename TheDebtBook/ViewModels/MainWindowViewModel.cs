using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Dynamic;
using System.Runtime.CompilerServices;
using Prism.Mvvm;
using TheDebtBook.Annotations;
using Prism.Commands;
using System.Windows.Input;
using TheDebtBook.ViewModels;

namespace TheDebtBook
{
    public class MainWindowViewModel : BindableBase
    {

        private DebtBookModel _model;
        private int currentIndex;
        private NavigationService _navigationService;

        public MainWindowViewModel(DebtBookModel model, NavigationService navigationService)
        {
            _model = model;
            currentIndex = _model.CurrentIndex;
            _navigationService = navigationService;
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
        private ICommand _addDepitorCommand;


        public ICommand AddDeptToDebitorCommand
        {
            get
            {
                return _addDeptToDebitorCommand ?? (_addDeptToDebitorCommand = new DelegateCommand(() =>
          {

          }, () =>
          {
              return CurrentIndex >= 0;
          }
                       ).ObservesProperty(() => CurrentIndex));

            }
        }

        public ICommand AddDepitorCommand
        {
            get { return _addDepitorCommand ?? (_addDepitorCommand = new RelayCommand(AddDebitor)); }
        }




        private void AddDebitor()
        {
            AddDebitorViewModel addDebitorViewModel = new AddDebitorViewModel(_model);
            _navigationService.ShowDebitorView(addDebitorViewModel);
        }

        

        #endregion
    }

    public class DebitorNameTotalDept
    {
        public string Name { get; set; }
        public double TotalDept { get; set; }
    }


}