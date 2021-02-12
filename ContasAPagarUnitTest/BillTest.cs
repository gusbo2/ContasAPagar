using ContasAPagar.Data.Entities;
using System;
using Xunit;

namespace ContasAPagarUnitTest
{
    public class BillTest
    {
        [Theory]
        [InlineData(-5, "Luz", 50.00, "12/02/2020", "07/02/2020")]
        [InlineData(0, "Luz", 50.00, "12/02/2020", "12/02/2020")]
        [InlineData(3, "Luz", 50.00, "12/02/2020", "15/02/2020")]
        [InlineData(5, "Luz", 50.00, "12/02/2020", "17/02/2020")]
        [InlineData(10, "Luz", 50.00, "12/02/2020", "22/02/2020")]
        public void DaysInArrearsTest(int expected, string name, double value, string expirationDate, string payDate)
        {
            var bill = new Bill(name, value, DateTime.Parse(expirationDate), DateTime.Parse(payDate));
            Assert.Equal(expected, bill.GetDaysInArrears());
        }
        
        [Theory]
        [InlineData(0, "Luz", 50.00, "12/02/2020", "07/02/2020")]
        [InlineData(0, "Luz", 50.00, "12/02/2020", "12/02/2020")]
        [InlineData(0.02, "Luz", 50.00, "12/02/2020", "15/02/2020")]
        [InlineData(0.03, "Luz", 50.00, "12/02/2020", "17/02/2020")]
        [InlineData(0.05, "Luz", 50.00, "12/02/2020", "22/02/2020")]
        public void MultaTest(double expected, string name, double value, string expirationDate, string payDate)
        {
            var bill = new Bill(name, value, DateTime.Parse(expirationDate), DateTime.Parse(payDate));
            var (multa, _) = bill.GetTaxes();
            Assert.Equal(expected, multa);
        }

        [Theory]
        [InlineData(0, "Luz", 50.00, "12/02/2020", "07/02/2020")]
        [InlineData(0, "Luz", 50.00, "12/02/2020", "12/02/2020")]
        [InlineData(0.001, "Luz", 50.00, "12/02/2020", "15/02/2020")]
        [InlineData(0.002, "Luz", 50.00, "12/02/2020", "17/02/2020")]
        [InlineData(0.003, "Luz", 50.00, "12/02/2020", "22/02/2020")]
        public void JuroTest(double expected, string name, double value, string expirationDate, string payDate)
        {
            var bill = new Bill(name, value, DateTime.Parse(expirationDate), DateTime.Parse(payDate));
            var (_, juros) = bill.GetTaxes();
            Assert.Equal(expected, juros);
        }

        [Theory]
        [InlineData(50.00, "Luz", 50.00, "12/02/2020", "07/02/2020")]
        [InlineData(50.00, "Luz", 50.00, "12/02/2020", "12/02/2020")]
        [InlineData(51.15, "Luz", 50.00, "12/02/2020", "15/02/2020")]
        [InlineData(52.02, "Luz", 50.00, "12/02/2020", "17/02/2020")]
        [InlineData(54.08, "Luz", 50.00, "12/02/2020", "22/02/2020")]
        public void CalculateTaxesTest(double expected, string name, double value, string expirationDate, string payDate)
        {
            var bill = new Bill(name, value, DateTime.Parse(expirationDate), DateTime.Parse(payDate));
            var correctedValue = bill.CalculateTaxes();
            Assert.Equal(expected, correctedValue);
        }
    }
}
