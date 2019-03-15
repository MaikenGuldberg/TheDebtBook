using System;

namespace TheDebtBook
{
    public class Debt
    {
        private double _value;
        private DateTime _date;

        public double Value
        {
            get => _value;
            set => _value = value;
        }

        public DateTime Date
        {
            get => _date;
            set => _date = value;
        }

        public Debt(double value, DateTime date)
        {
            _value = value;
            _date = date;
        }
    }
}