using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace graphApi.DataAccess.Entity
{
    public class Product
    {
        [Key]
        public int Id { get; set; }
        public string Handle { get; set; } = string.Empty;
        public bool AvailableForSale { get; set; }
        public string Title { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;
        public string? DescriptionHtml { get; set; } = string.Empty;

        public Image? FeaturedImage { get; set; }

        [UsePaging]
        public ICollection<Image>? Images { get; set; }

        public List<ProductOption> Options { get; set; } = [];

        [UsePaging]
        public ICollection<ProductVariant> Variants { get; set; } = [];
        public Seo? Seo { get; set; }
        public string[] Tags { get; set; } = [];
        public DateTime? UpdatedAt { get; set; }

        public DateTime CreatedAt { get; set; } = DateTime.Now;

        public Money Price { get; set; } = new(0);
        public PriceRange PriceRange { get; set; } = new(0, 0);
    }

    public class PriceRange(double minVariantPrice, double maxVariantPrice)
    {
        [Key]
        public int Id { get; set; }
        public double MaxVariantPrice { get; set; } = maxVariantPrice;
        public double MinVariantPrice { get; set; } = minVariantPrice;
    }

    public class ProductVariant
    {
        [Key]
        public int Id { get; set; }
        public string Title { get; set; } = string.Empty;
        public bool AvailableForSale { get; set; }
        public List<SelectedOptions> SelectedOptions { get; set; } = [];
        public Money Price { get; set; } = new(0);

        [ForeignKey("Product")]
        public int ProductId { get; set; }
        public Product Product { get; set; }
    }

    public class SelectedOptions
    {
        [Key]
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public string Value { get; set; } = string.Empty;
    }

    public class ProductOption
    {
        [Key]
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public string[] Values { get; set; } = [];
    }

    public class Collection
    {
        [Key]
        public int Id { get; set; }
        public string Title { get; set; } = string.Empty;
        public string? Path { get; set; } = string.Empty; //TODO: Remove?
        public string Handle { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;
        public DateTime? UpdatedAt { get; set; }
        public Seo? Seo { get; set; }

        [UsePaging]
        [UseFiltering]
        [UseSorting]
        public ICollection<Product>? Products { get; set; } = [];
    }
}
