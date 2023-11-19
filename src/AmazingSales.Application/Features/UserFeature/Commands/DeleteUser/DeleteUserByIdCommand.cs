using MediatR;
using AmazingSales.Domain.Entities;
using AmazingSales.Application.Interfaces.Repositories;

namespace AmazingSales.Application.Features.UserFeature.Commands.DeleteUserById
{
    public record DeleteUserByIdCommand : IRequest<User?>
    {
        public long Id { get; set; }
    }

    internal class DeleteUserByIdCommandHandler : IRequestHandler<DeleteUserByIdCommand, User?>
    {
        private readonly IUnitOfWork _unitOfWork;

        public DeleteUserByIdCommandHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<User?> Handle(DeleteUserByIdCommand request, CancellationToken cancellationToken)
        {
            var deletedUser = await _unitOfWork.Repository<User, long>().DeleteByIdAsync(request.Id);
            if (deletedUser is null)
                return null;

            deletedUser.AddDomainEvent(new UserDeletedByIdEvent(deletedUser));
            await _unitOfWork.Save(cancellationToken);
            return deletedUser;
        }
    }
}
