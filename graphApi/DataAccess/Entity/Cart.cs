using System.ComponentModel.DataAnnotations;

namespace graphApi.DataAccess.Entity
{
    public class Cart
    {
        [Key]
        public Guid Id { get; set; }
        public string CheckoutUrl { get; set; } = string.Empty;
        public Cost? Cost { get; set; }

        [UsePaging]
        public ICollection<CartItem> Lines { get; set; } = [];
        public int TotalQuantity { get; set; } = 0;
    }

    public class Cost
    {
        [Key]
        public int Id { get; set; }
        public double? SubtotalAmount { get; set; }
        public double? TotalAmount { get; set; }
        public double TotalTaxAmount { get; set; }
    }

    public class CartItem
    {
        [Key]
        public int Id { get; set; }
        public int Quantity { get; set; }
        public Cost Cost { get; set; } = new();
        public ProductVariant Merchandise { get; set; } = new();
    }
}
