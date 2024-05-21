using graphApi.DataAccess.Entity;
using Microsoft.EntityFrameworkCore;

namespace graphApi.DataAccess.DAO
{
    public class MenuRepository
    {
        private readonly SampleAppDbContext _sampleAppDbContext;

        public MenuRepository(SampleAppDbContext sampleAppDbContext)
        {
            _sampleAppDbContext = sampleAppDbContext;
        }

        public Menu? GetMenu(string handle)
        {
            return _sampleAppDbContext
                .Menu.Where(e => e.Handle == handle)
                .Include(e => e.Items)
                .FirstOrDefault();
            ;
        }
    }
}
