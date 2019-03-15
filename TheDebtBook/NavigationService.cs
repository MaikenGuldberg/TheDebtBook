using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Policy;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows;
using TheDebtBook.Views;

namespace TheDebtBook
{
    public class NavigationService : INavigationService
    {
        private AddDebitorView _addDebitorView;
        private AddDeptToDebitorView _addDeptToDebitorView;

        public NavigationService()
        {

        }

        public void ShowView(object ViewModel)
        {
            string ViewModelName = ViewModel.GetType().Name;

            switch (ViewModelName)
            {
                case "AddDebitorViewModel":
                    _addDebitorView = new AddDebitorView();
                    _addDebitorView.DataContext = ViewModel;
                    _addDebitorView.Show();
                    break;
                case "AddDebtToDebitorViewModel":
                    _addDeptToDebitorView = new AddDeptToDebitorView();
                    _addDeptToDebitorView.DataContext = ViewModel;
                    _addDeptToDebitorView.Show();
                    break;
            }
        }

        public void HideView(object ViewModel)
        {
            string ViewModelName = ViewModel.GetType().Name;

            switch (ViewModelName)
            {
                case "AddDebitorViewModel":
                    _addDebitorView.Hide();
                    break;
                case "AddDebtToDebitorViewModel":
                    _addDeptToDebitorView.Hide();
                    break;
            }
        }

        public void CloseView(object ViewModel)
        {
            string ViewModelName = ViewModel.GetType().Name;

            switch (ViewModelName)
            {
                case "AddDebitorViewModel":
                    _addDebitorView.Close();
                    break;
                case "AddDebtToDebitorViewModel":
                    _addDeptToDebitorView.Close();
                    break;
            }
        }
    }
}
