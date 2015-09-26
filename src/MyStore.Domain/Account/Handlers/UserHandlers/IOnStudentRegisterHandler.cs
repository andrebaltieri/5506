using DomainNotificationHelper;
using MyStore.Domain.Account.Events.UserEvents;

namespace MyStore.Domain.Account.Handlers.UserHandlers
{
    public interface IOnStudentRegisterHandler : IHandler<OnUserRegisteredEvent>
    {
    }
}
