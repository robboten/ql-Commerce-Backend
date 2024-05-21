using graphApi.DataAccess.Entity;
using Microsoft.EntityFrameworkCore;

namespace graphApi.DataAccess.DAO
{
    public class ProductRepository
    {
        private readonly SampleAppDbContext _sampleAppDbContext;

        public ProductRepository(SampleAppDbContext sampleAppDbContext)
        {
            _sampleAppDbContext = sampleAppDbContext;
        }

        public IQueryable<Product> GetAllProducts()
        {
            return _sampleAppDbContext
                .Product.Include(e => e.Seo)
                .Include(e => e.PriceRange)
                .Include(e => e.Images)
                .Include(e => e.FeaturedImage);
        }

        public Product? GetProductByHandle(string handle)
        {
            var product = _sampleAppDbContext
                .Product.Include(e => e.Seo)
                .Include(e => e.PriceRange)
                .Include(e => e.Images)
                .Include(e => e.FeaturedImage)
                .Include(e => e.Variants)
                .ThenInclude(v => v.SelectedOptions)
                .Include(e => e.Variants)
                .ThenInclude(v => v.Price)
                .Include(e => e.Options)
                .Where(e => e.Handle == handle)
                .FirstOrDefault();

            //if (product is not null)
            //{
            //    var pMax = product.Variants.Max(v => v.Price.Amount);
            //    var pMin = product.Variants.Min(v => v.Price.Amount);
            //    product.PriceRange = new(pMin, pMax);
            //}

            return product;
        }

        public IEnumerable<Product> GetProductsByQuery(string query)
        {
            return
            [
                .. _sampleAppDbContext
                    .Product.Include(e => e.Seo)
                    .Include(e => e.PriceRange)
                    .Include(e => e.Images)
                    .Include(e => e.FeaturedImage)
                    .Where(e => e.Handle.Contains(query))
            ];
        }
    }
}
