using System;

namespace ContasAPagar.Dtos.Bills
{
    public class GetBillDto
    {
        public string Name { get; set; }
        public double Value { get; set; }
        public double CorrectedValue { get; set; }
        public int DaysInArrears { get; set; }
        public DateTime PayDate { get; set; }
    }
}