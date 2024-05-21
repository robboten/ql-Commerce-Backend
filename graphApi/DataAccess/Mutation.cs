using graphApi.DataAccess.DAO;
using graphApi.DataAccess.Entity;
using HotChocolate.Subscriptions;
using static graphApi.DataAccess.DAO.CartRepository;

namespace graphApi.DataAccess
{
    public class Mutation
    {
        public async Task<Department> CreateDepartment(
            [Service] DepartmentRepository departmentRepository,
            [Service] ITopicEventSender eventSender,
            string departmentName,
            CancellationToken cancellationToken
        )
        {
            var newDepartment = new Department { Name = departmentName };
            var createdDepartment = await departmentRepository.CreateDepartment(newDepartment);

            await eventSender.SendAsync("DepartmentCreated", createdDepartment, cancellationToken);

            return createdDepartment;
        }

        public async Task<Cart> CartCreateWCart(
            [Service] CartRepository cartRepository,
            [Service] ITopicEventSender eventSender,
            Cart cart,
            CancellationToken cancellationToken
        )
        {
            var createdCart = await cartRepository.CreateCart(cart);

            await eventSender.SendAsync("CartCreated", createdCart, cancellationToken);

            return createdCart;
        }

        public async Task<Cart> AddToCart(
            [Service] CartRepository cartRepository,
            [Service] ITopicEventSender eventSender,
            string id,
            LineItem[] lines,
            CancellationToken cancellationToken
        )
        {
            var updatedCart = await cartRepository.AddToCart(id, lines);

            await eventSender.SendAsync("CartUpdated", updatedCart, cancellationToken);

            return updatedCart;
        }

        public async Task<Cart> CartLinesUpdate(
    [Service] CartRepository cartRepository,
    [Service] ITopicEventSender eventSender,
    string cartId,
    CartLineUpdateInput[] lines,
    CancellationToken cancellationToken
)
        {
            var updatedCart = await cartRepository.UpdateCart(cartId, lines);

            await eventSender.SendAsync("CartUpdated", updatedCart, cancellationToken);

            return updatedCart;
        }

        public async Task<Cart> CartLinesRemove(
            [Service] CartRepository cartRepository,
            [Service] ITopicEventSender eventSender,
            string cartId,
            int[] lineIds,
            CancellationToken cancellationToken
        )
        {
            var updatedCart = await cartRepository.RemoveFromCart(cartId, lineIds);

            await eventSender.SendAsync("CartUpdated", updatedCart, cancellationToken);

            return updatedCart;
        }

        public async Task<Cart> CartCreate(
            [Service] CartRepository cartRepository,
            [Service] ITopicEventSender eventSender,
            CancellationToken cancellationToken
        )
        {
            var createdCart = await cartRepository.CreateCart();

            await eventSender.SendAsync("CartCreated", createdCart, cancellationToken);

            return createdCart;
        }

        public async Task<Cart> CartCreateWithItems(
            [Service] CartRepository cartRepository,
            [Service] ITopicEventSender eventSender,
            CancellationToken cancellationToken,
            LineItem[] lines
        )
        {
            var createdCart = await cartRepository.CreateCart(lines);

            await eventSender.SendAsync("CartCreated", createdCart, cancellationToken);

            return createdCart;
        }

        public async Task<Employee> CreateEmployeeWithDepartmentId(
            [Service] EmployeeRepository employeeRepository,
            string name,
            int age,
            string email,
            int departmentId
        )
        {
            Employee newEmployee = new Employee
            {
                Name = name,
                Age = age,
                Email = email,
                DepartmentId = departmentId
            };

            var createdEmployee = await employeeRepository.CreateEmployee(newEmployee);
            return createdEmployee;
        }

        public async Task<Employee> CreateEmployeeWithDepartment(
            [Service] EmployeeRepository employeeRepository,
            string name,
            int age,
            string email,
            string departmentName
        )
        {
            Employee newEmployee = new Employee
            {
                Name = name,
                Age = age,
                Email = email,
                Department = new Department { Name = departmentName }
            };

            var createdEmployee = await employeeRepository.CreateEmployee(newEmployee);
            return createdEmployee;
        }
    }
}
