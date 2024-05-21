using graphApi.DataAccess.Entity;
using Microsoft.EntityFrameworkCore;

namespace graphApi.DataAccess.DAO
{
    public static class DbContextExtensions
    {
        public static IQueryable<Cart> IncludeCartDetails(this IQueryable<Cart> query)
        {
            return query
                .Include(c => c.Lines)
                .ThenInclude(l => l.Cost)
                .ThenInclude(c => c.SubtotalAmount)
                .Include(c => c.Lines)
                .ThenInclude(l => l.Cost)
                .ThenInclude(c => c.TotalAmount)
                .Include(c => c.Lines)
                .ThenInclude(l => l.Cost)
                .ThenInclude(c => c.TotalTaxAmount)
                .Include(c => c.Lines)
                .ThenInclude(l => l.Merchandise)
                .Include(c => c.Lines)
                .ThenInclude(l => l.Merchandise)
                .ThenInclude(m => m.SelectedOptions)
                .Include(c => c.Lines)
                .ThenInclude(l => l.Merchandise)
                .ThenInclude(m => m.Price)
                .Include(c => c.Lines)
                .ThenInclude(l => l.Merchandise);
        }

        public static IQueryable<Cart> IncludeCost(this IQueryable<Cart> query)
        {
            return query
                .Include(l => l.Cost)
                .ThenInclude(c => c.SubtotalAmount)
                .Include(l => l.Cost)
                .ThenInclude(c => c.TotalAmount)
                .Include(l => l.Cost)
                .ThenInclude(c => c.TotalTaxAmount);
        }

        public static IQueryable<Cart> IncludeProduct(this IQueryable<Cart> query)
        {
            return query
                .Include(c => c.Lines)
                .ThenInclude(l => l.Merchandise)
                .ThenInclude(m => m.Product)
                .ThenInclude(p => p.FeaturedImage);
        }
    }
}
