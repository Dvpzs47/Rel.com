using System.Threading.Tasks;
using Rel.SharedKernel;

namespace Rel.SharedKernel.Interfaces
{
    public interface IHandle<in T> where T : BaseDomainEvent
    {
        Task Handle(T domainEvent);
    }
}