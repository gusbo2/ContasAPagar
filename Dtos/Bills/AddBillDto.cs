using System;

namespace ContasAPagar.Dtos.Bills
{
    public class AddBillDto
    {
        public string Name { get; set; }
        public double Value { get; set; }
        public DateTime ExpirationDate { get; set; }
        public DateTime PayDate { get; set; }
    }
}