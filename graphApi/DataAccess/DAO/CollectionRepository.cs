using graphApi.DataAccess.Entity;
using Microsoft.EntityFrameworkCore;

namespace graphApi.DataAccess.DAO
{
    public class CollectionRepository
    {
        private readonly SampleAppDbContext _sampleAppDbContext;

        public CollectionRepository(SampleAppDbContext sampleAppDbContext)
        {
            _sampleAppDbContext = sampleAppDbContext;
        }

        public List<Collection> GetAllCollections()
        {
            return [.. _sampleAppDbContext.Collection.Include(e => e.Products).Include(e => e.Seo)];
        }

        public Collection? GetCollectionByHandle(string handle)
        {
            var collection = _sampleAppDbContext
                .Collection.Include(e => e.Products)
                .ThenInclude(p => p.Price)
                .Include(e => e.Products)
                .ThenInclude(p => p.Images)
                .Include(e => e.Products)
                .ThenInclude(p => p.FeaturedImage)
                .Include(e => e.Products)
                .ThenInclude(p => p.Seo)
                .Include(e => e.Products)
                .ThenInclude(p => p.PriceRange)
                .Include(e => e.Products)
                .ThenInclude(p => p.Variants)
                .ThenInclude(v => v.SelectedOptions)
                .Include(e => e.Products)
                .ThenInclude(p => p.Variants)
                .ThenInclude(v => v.Price)
                .Include(e => e.Seo)
                .Where(e => e.Handle == handle)
                .FirstOrDefault();

            return collection;
        }
    }
}
