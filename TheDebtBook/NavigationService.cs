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

        public void ShowView(View view)
        {
            switch (view)
            {
                case View.AddDebitor:
                    if (_addDebitorView == null)
                    {
                        _addDebitorView = new AddDebitorView();
                    }
                    _addDebitorView.Show();
                    break;
                case View.AddDebtToDebitor:
                    if (_addDeptToDebitorView == null)
                    {
                        _addDeptToDebitorView = new AddDeptToDebitorView();
                    }
                    _addDeptToDebitorView.Show();
                    break;
            }
        }

        public void CloseView(View view)
        {
            switch (view)
            {
                case View.AddDebitor:
                    _addDebitorView.Hide();
                    break;
                case View.AddDebtToDebitor:
                    _addDeptToDebitorView.Hide();
                    break;
            }
        }

        public void ShowView(object ViewModel)
        {
            string ViewModelName = typeof(object).Name;

            switch (ViewModelName)
            {
                case "AddDebitorViewModel":
                    if (_addDebitorView == null)
                    {
                        _addDebitorView = new AddDebitorView();
                        _addDebitorView.DataContext = ViewModel;
                    }
                    _addDebitorView.Show();
                    break;
                case "AddDebtToDebitorViewModel":
                    if (_addDeptToDebitorView == null)
                    {
                        _addDeptToDebitorView = new AddDeptToDebitorView();
                    }
                    _addDeptToDebitorView.Show();
                    break;
            }
        }

        public void HideView(object ViewModel)
        {
            string ViewModelName = typeof(object).Name;

            switch (ViewModelName)
            {
                case "AddDebitorViewModel":
                    if (_addDebitorView == null)
                    {
                        _addDebitorView = new AddDebitorView();
                    }
                    _addDebitorView.Hide();
                    break;
                case "AddDebtToDebitorViewModel":
                    if (_addDeptToDebitorView == null)
                    {
                        _addDeptToDebitorView = new AddDeptToDebitorView();
                    }
                    _addDeptToDebitorView.Hide();
                    break;
            }
        }

        public void CloseView(object ViewModel)
        {
            string ViewModelName = typeof(object).Name;

            switch (ViewModelName)
            {
                case "AddDebitorViewModel":
                    if (_addDebitorView == null)
                    {
                        _addDebitorView = new AddDebitorView();
                    }
                    _addDebitorView.Close();
                    break;
                case "AddDebtToDebitorViewModel":
                    if (_addDeptToDebitorView == null)
                    {
                        _addDeptToDebitorView = new AddDeptToDebitorView();
                    }
                    _addDeptToDebitorView.Close();
                    break;
            }
        }
    }

    public enum View
    {
        AddDebitor,
        AddDebtToDebitor
    }
}
