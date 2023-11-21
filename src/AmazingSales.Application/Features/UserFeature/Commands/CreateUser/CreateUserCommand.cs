using MediatR;
using AmazingSales.Domain.Entities;
using AmazingSales.Application.Interfaces.Repositories;

namespace AmazingSales.Application.Features.UserFeature.Commands
{
    public record CreateUserCommand : IRequest<long>
    {
        public string? Name { get; set; }
        public string? Phone { get; set; }
        public string? Email { get; set; }
    }

    internal class CreateUserCommandHandler : IRequestHandler<CreateUserCommand, long>
    {
        private readonly IUnitOfWork _unitOfWork;

        public CreateUserCommandHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<long> Handle(CreateUserCommand request, CancellationToken cancellationToken)
        {
            // Creating a new user entity and mapping the properties of the command
            // object with the player entity.
            var user = new User(request.Name!, request.Email!, request.Phone);

            // Adding the user in the database using the generic AddAsync method.
            user = await _unitOfWork.Repository<User, long>().AddAsync(user);

            // Adding the UserCreatedEvent event in the domain events collection
            // available in BaseEntity class.
            user.AddDomainEvent(new UserCreatedEvent(user));

            // Saving changes of adding the user
            await _unitOfWork.Save(cancellationToken);

            // Return id of the new user
            return user.Id;
        }
    }

}
