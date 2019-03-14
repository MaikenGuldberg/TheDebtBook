using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Policy;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using TheDebtBook.Views;

namespace TheDebtBook
{
    public class NavigationService : INavigationService
    {
        public void ShowDebitorView(AddDebitorViewModel addDebitorViewModel)
        {
            AddDebitorView addDebitorView = new AddDebitorView();
            addDebitorView.Show();
        }
    }
}
