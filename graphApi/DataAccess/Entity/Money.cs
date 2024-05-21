using System.ComponentModel.DataAnnotations;

namespace graphApi.DataAccess.Entity
{
    public class Money
    {
        [Key]
        public int Id { get; set; }
        public double Amount { get; set; } = 0;
        public string CurrencyCode { get; set; } = "SEK";

        public Money(double amount)
        {
            Amount = amount;
        }

        public Money() { }
    }
}
