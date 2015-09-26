using DomainNotificationHelper.Events;
using MyStore.Domain.Account.Commands.UserCommands;
using MyStore.Domain.Account.Entities;
using MyStore.Domain.Account.Events.UserEvents;
using MyStore.Domain.Account.Repositories;
using MyStore.Domain.Account.Services;
using MyStore.Infra.Transaction;

namespace MyStore.ApplicationService.Services.Account
{
    public class UserApplicationService : ApplicationService, IUserApplicationService
    {
        private readonly IUserRepository _repository;

        public UserApplicationService(IUserRepository repository, IUnitOfWork uow)
            : base(uow)
        {
            _repository = repository;
        }

        public User Register(RegisterUserCommand command)
        {
            // Cria a instâcia do usuário
            var user = new User(command.Email, command.Username, command.Password);

            // Tenta registrar o usuário
            user.Register();

            // Chama o commit
            if(Commit())
            {
                // Dispara o evento de usuário registrado
                DomainEvent.Raise(new OnUserRegisteredEvent(user));

                // Retorna o usuário
                return user;
            }

            // Se não comitou, retorna nulo
            return null;
        }
    }
}
