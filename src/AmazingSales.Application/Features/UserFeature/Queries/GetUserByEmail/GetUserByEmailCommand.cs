using MediatR;
using AmazingSales.Domain.Entities;
using AmazingSales.Application.Interfaces.Repositories;

namespace AmazingSales.Application.Features.UserFeature.Queries.GetUserByEmail
{
    public record GetUserByEmailQuery : IRequest<User?>
    {
        public string? Email { get; set; }
    }

    internal class GetUserByEmailQueryHandler : IRequestHandler<GetUserByEmailQuery, User?>
    {
        private readonly IUserRepository _userRepository;

        public GetUserByEmailQueryHandler(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        public async Task<User?> Handle(GetUserByEmailQuery request, CancellationToken cancellationToken)
        {
            return await _userRepository.GetUserByEmail(request.Email!);
        }
    }
}
