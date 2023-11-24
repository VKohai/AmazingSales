using MediatR;
using AutoMapper;
using AmazingSales.Domain.Entities;
using AutoMapper.QueryableExtensions;
using AmazingSales.Application.Extensions;
using AmazingSales.Application.Features.Common;
using AmazingSales.Application.Interfaces.Repositories;

namespace AmazingSales.Application.Features.UserFeature.Queries
{
    public class GetUsersWithPaginationQueryHandler : IRequestHandler<PaginationQuery<GetUsersWithPaginationDto>,
        IEnumerable<GetUsersWithPaginationDto>>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public GetUsersWithPaginationQueryHandler(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public Task<IEnumerable<GetUsersWithPaginationDto>> Handle(
            PaginationQuery<GetUsersWithPaginationDto> request,
            CancellationToken cancellationToken)
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