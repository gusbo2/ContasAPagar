using System;

namespace ContasAPagar.Dtos.Bills
{
    public class UpdatedBillDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public double Value { get; set; }
        public DateTime ExpirationDate { get; set; }
        public DateTime PayDate { get; set; }
    }
}