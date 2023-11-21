using MediatR;
using AmazingSales.Domain.Entities;
using AmazingSales.Application.Interfaces.Repositories;

namespace AmazingSales.Application.Features.UserFeature.Queries
{
    public record GetUserByIdQuery(long Id) : IRequest<User>;

    internal class GetUserByIdQueryHandler : IRequestHandler<GetUserByIdQuery, User>
    {
        private readonly IUnitOfWork _unitOfWork;

        public GetUserByIdQueryHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<User> Handle(GetUserByIdQuery request, CancellationToken cancellationToken)
        {
            return await _unitOfWork.Repository<User, long>().GetByIdAsync(request.Id);
        }
    }
}
