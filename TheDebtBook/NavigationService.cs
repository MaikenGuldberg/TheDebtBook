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
    public class NavigationService
    {
        private AddDebitorView _addDebitorView;
        private AddDeptToDebitorView _addDeptToDebitorView;

        public NavigationService()
        {
            _addDebitorView = new AddDebitorView();
            _addDeptToDebitorView = new AddDeptToDebitorView();
        }

        public void ShowView(View view)
        {
            switch (view)
            {
                case View.AddDebitor:
                    _addDebitorView.Show();
                    break;
                case View.AddDebtToDebitor:
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
    }

    public enum View
    {
        AddDebitor,
        AddDebtToDebitor
    }
}
