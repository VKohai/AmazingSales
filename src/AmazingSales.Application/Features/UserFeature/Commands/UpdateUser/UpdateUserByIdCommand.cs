using MediatR;
using AmazingSales.Domain.Entities;
using AmazingSales.Application.Interfaces.Repositories;

namespace AmazingSales.Application.Features.UserFeature.Commands.UpdateUser
{
    public record UpdateUserByIdCommand : IRequest<User?>
    {
        public long Id { get; set; }
    }

    public class UpdateUserByIdCommandHandler : IRequestHandler<UpdateUserByIdCommand, User?>
    {
        private readonly IUnitOfWork _unitOfWork;

        public UpdateUserByIdCommandHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<User?> Handle(UpdateUserByIdCommand request, CancellationToken cancellationToken)
        {
            var updatedUser = await _unitOfWork.Repository<User, long>().UpdateByIdAsync(request.Id);
            if (updatedUser is null)
                return null;

            updatedUser.AddDomainEvent(new UserUpdatedByIdEvent(updatedUser));
            await _unitOfWork.Save(cancellationToken);
            return updatedUser;
        }
    }
}
