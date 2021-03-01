using System.Threading.Tasks;
using Rel.SharedKernel.Interfaces;
using Rel.SharedKernel;

namespace Rel.UnitTests
{
    public class NoOpDomainEventDispatcher : IDomainEventDispatcher
    {
        public Task Dispatch(BaseDomainEvent domainEvent)
        {
            return Task.CompletedTask;
        }
    }
}
