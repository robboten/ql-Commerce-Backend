using System.Globalization;
using System.Reflection.Metadata;
using graphApi.DataAccess.DAO;
using graphApi.DataAccess.Entity;
using HotChocolate.Subscriptions;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory;

namespace graphApi.DataAccess
{
    public class Query
    {
        //TODO: global filtering https://chillicream.com/docs/hotchocolate/v13/fetching-data/filtering
        [UsePaging(IncludeTotalCount = true, MaxPageSize = 100)]
        [UseFiltering]
        [UseSorting]
        public IQueryable<Product> Products([Service] ProductRepository productRepository)
        {
            var query = productRepository.GetAllProducts();
            return query;
        }

        public async Task<Product?> GetProduct(
            [Service] ProductRepository productRepository,
            [Service] ITopicEventSender eventSender,
            string handle
        )
        {
            Product? gottenProduct = productRepository.GetProductByHandle(handle);
            await eventSender.SendAsync("ReturnedProduct", gottenProduct);
            return gottenProduct;
        }

        public Menu? Menu([Service] MenuRepository menuRepository, string handle) =>
            menuRepository.GetMenu(handle);

        [UsePaging(MaxPageSize = 100)]
        public List<Collection> Collections([Service] CollectionRepository collectionRepository) =>
            collectionRepository.GetAllCollections();

        public async Task<Collection?> Collection(
            [Service] CollectionRepository collectionRepository,
            [Service] ITopicEventSender eventSender,
            string handle
        )
        {
            Collection? gottenCollection = collectionRepository.GetCollectionByHandle(handle);
            await eventSender.SendAsync("ReturnedCollection", gottenCollection);
            return gottenCollection;
        }

        [UsePaging(MaxPageSize = 100)]
        public List<Page> Pages([Service] PageRepository pagesRepository) =>
            pagesRepository.GetAllPages();

        public Page? PageByHandle([Service] PageRepository pageRepository, string handle) =>
            pageRepository.GetPageByHandle(handle);

        public Cart? Cart([Service] CartRepository cartRepository, string id) =>
            cartRepository.GetCart(id);

        public List<Cart> AllCarts([Service] CartRepository cartRepository) =>
            cartRepository.GetAllCarts();

        //public List<Employee> AllEmployeeWithDepartment(
        //    [Service] EmployeeRepository employeeRepository
        //) => employeeRepository.GetEmployeesWithDepartment();

        //public async Task<Employee> GetEmployeeById(
        //    [Service] EmployeeRepository employeeRepository,
        //    [Service] ITopicEventSender eventSender,
        //    int id
        //)
        //{
        //    Employee gottenEmployee = employeeRepository.GetEmployeeById(id);
        //    await eventSender.SendAsync("ReturnedEmployee", gottenEmployee);
        //    return gottenEmployee;
        //}

        //    public List<Employee> AllEmployeeOnly([Service] EmployeeRepository employeeRepository) =>
        //employeeRepository.GetEmployees();
    }
}
