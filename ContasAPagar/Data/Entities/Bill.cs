using System;

namespace ContasAPagar.Data.Entities
{
    public class Bill : EntityBase
    {
        public Bill(string name, double value, DateTime expirationDate, DateTime payDate)
        {
            Name = name;
            Value = value;
            ExpirationDate = expirationDate;
            PayDate = payDate;
        }

        public string Name { get; set; }
        public double Value { get; set; }
        public DateTime ExpirationDate { get; set; }
        public DateTime PayDate { get; set; }

        public double CalculateTaxes()
        {
            var (multa, juros) = GetTaxes();
            var correctedValue = Value + (Value * multa);
            correctedValue += ((correctedValue * juros) * GetDaysInArrears());
            return Math.Round(correctedValue, 2);
        }

        public (double, double) GetTaxes()
        {
            var daysInArrears = GetDaysInArrears();
            if (daysInArrears <= 0)
                return (0, 0);
            if (daysInArrears > 0 && daysInArrears <= 3)
                return (0.02, 0.001);
            if (daysInArrears > 3 && daysInArrears <= 5)
                return (0.03, 0.002);
            return (0.05, 0.003);
        }

        public int GetDaysInArrears() => (int)(PayDate - ExpirationDate).TotalDays;
    }
}