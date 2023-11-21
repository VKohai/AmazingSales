using MediatR;
using AmazingSales.Domain.Entities;
using AmazingSales.Application.Interfaces.Repositories;

namespace AmazingSales.Application.Features.UserFeature.Commands
{
    public record UpdateUserCommand(User User) : IRequest<User?>;

    public class UpdateUserCommandHandler : IRequestHandler<UpdateUserCommand, User?>
    {
        private readonly IUnitOfWork _unitOfWork;

        public UpdateUserCommandHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<User?> Handle(UpdateUserCommand request, CancellationToken cancellationToken)
        {
            var updatedUser = await _unitOfWork.Repository<User, long>().UpdateAsync(request.User);
            if (updatedUser is null)
                return null;

            updatedUser.AddDomainEvent(new UserUpdatedByIdEvent(updatedUser));
            await _unitOfWork.Save(cancellationToken);
            return updatedUser;
        }
    }
}