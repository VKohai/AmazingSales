using MediatR;
using AutoMapper;
using AutoMapper.QueryableExtensions;

using AmazingSales.Domain.Entities;
using AmazingSales.Application.Extensions;
using AmazingSales.Application.Interfaces.Repositories;

namespace AmazingSales.Application.Features.UserFeature.Queries
{
    public record GetUsersWithPaginationQuery : IRequest<IEnumerable<GetUsersWithPaginationDto>>
    {
        public int Count { get; set; }
        public int Offset { get; set; }
        public GetUsersWithPaginationQuery() { }
        public GetUsersWithPaginationQuery(int count, int offset) => (Count, Offset) = (count, offset);
    }

    public class GetUsersWithPaginationQueryHandler : IRequestHandler<GetUsersWithPaginationQuery, IEnumerable<GetUsersWithPaginationDto>>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public GetUsersWithPaginationQueryHandler(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public Task<IEnumerable<GetUsersWithPaginationDto>> Handle(GetUsersWithPaginationQuery request, CancellationToken cancellationToken)
        {
            return Task.FromResult(
                _unitOfWork.Repository<User, long>().Entities
                    .OrderBy(u => u.Id)
                    .ProjectTo<GetUsersWithPaginationDto>(_mapper.ConfigurationProvider)
                    .ToPaginatedCollection(request.Count, request.Offset)
                );
        }
    }
}
