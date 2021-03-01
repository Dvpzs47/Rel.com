using System.Threading.Tasks;
using Rel.SharedKernel;

namespace Rel.SharedKernel.Interfaces
{
    public interface IDomainEventDispatcher
    {
        Task Dispatch(BaseDomainEvent domainEvent);
    }
}