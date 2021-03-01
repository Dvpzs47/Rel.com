using System.Threading.Tasks;
using Ardalis.GuardClauses;
using Rel.Core.Events;
using Rel.SharedKernel.Interfaces;

namespace Rel.Core.Services
{
    public class ItemCompletedEmailNotificationHandler : IHandle<ToDoItemCompletedEvent>
    {
        public Task Handle(ToDoItemCompletedEvent domainEvent)
        {
            Guard.Against.Null(domainEvent, nameof(domainEvent));

            // Do Nothing
            return Task.CompletedTask;
        }
    }
}
