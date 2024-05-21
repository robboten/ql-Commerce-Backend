using graphApi.DataAccess.Entity;
using Microsoft.EntityFrameworkCore;

namespace graphApi.DataAccess.DAO
{
    public class PageRepository
    {
        private readonly SampleAppDbContext _sampleAppDbContext;

        public PageRepository(SampleAppDbContext sampleAppDbContext)
        {
            _sampleAppDbContext = sampleAppDbContext;
        }

        public List<Page> GetAllPages()
        {
            return _sampleAppDbContext.Page.Include(e => e.Seo).ToList();
        }

        public Page? GetPageByHandle(string handle)
        {
            return _sampleAppDbContext
                .Page.Where(e => e.Handle.Contains(handle))
                .Include(e => e.Seo)
                .FirstOrDefault();
        }
    }
}
