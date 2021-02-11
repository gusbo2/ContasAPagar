using System;

namespace ContasAPagar.Data.Entities
{
    public class Bill : EntityBase
    {
        public string Name { get; set; }
        public double Value { get; set; }
        public DateTime ExpirationDate { get; set; }
        public DateTime PayDate { get; set; }
    }
}