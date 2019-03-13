using System.Collections.Generic;
using System.Windows.Documents;

namespace TheDebtBook
{
    public class Debitor
    {
        private string _name;
        private List<Debt> _debts;

        public Debitor(string name)
        {
            _name = name;
            _debts = new List<Debt>();
        }

        public Debitor(string name, List<Debt> debts)
        {
            _name = name;
            _debts = debts;
        }

        public string Name
        {
            get => _name;
            set => _name = value;
        }

        public List<Debt> Debts
        {
            get => _debts;
            set => _debts = value;
        }
    }
}