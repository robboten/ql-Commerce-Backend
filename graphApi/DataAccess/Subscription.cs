using graphApi.DataAccess.Entity;
using HotChocolate.Execution;
using HotChocolate.Subscriptions;

namespace graphApi.DataAccess
{
    public class Subscription
    {
        public async ValueTask<ISourceStream<Department>> OnDepartmentCreate(
            ITopicEventReceiver eventReceiver,
            CancellationToken cancellationToken
        )
        {
            return await eventReceiver.SubscribeAsync<Department>(
                "DepartmentCreated",
                cancellationToken
            );
        }

        [Subscribe(With = nameof(OnDepartmentCreate))]
        public Department DepartmentCreated([EventMessage] Department department) => department;

        [SubscribeAndResolve]
        public async ValueTask<ISourceStream<Employee>> OnEmployeeGet(
            [Service] ITopicEventReceiver eventReceiver,
            CancellationToken cancellationToken
        )
        {
            return await eventReceiver.SubscribeAsync<Employee>(
                "ReturnedEmployee",
                cancellationToken
            );
        }
    }
}
