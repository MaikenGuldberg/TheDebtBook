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

        public void ShowView(AddDebitorViewModel addDebitorViewModel)
        {
            _addDebitorView = new AddDebitorView();
            _addDebitorView.Show();
        }

        public void CloseView(AddDebitorViewModel addDebitorViewModel)
        {
            _addDebitorView.Close();
        }
    }
}
