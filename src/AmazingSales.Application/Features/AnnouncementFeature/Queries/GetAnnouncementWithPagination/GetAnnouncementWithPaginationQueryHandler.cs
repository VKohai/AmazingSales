using System.Collections;
using AmazingSales.Application.Features.Common;
using MediatR;

namespace AmazingSales.Application.Features.AnnouncementFeature.Queries.GetAnnouncementWithPagination;

public class GetAnnouncementWithPaginationQueryHandler
    : IRequestHandler<PaginationQuery<GetAnnouncementWithPaginationDto>, IEnumerable<GetAnnouncementWithPaginationDto>>
{
    public Task<IEnumerable<GetAnnouncementWithPaginationDto>> Handle(
        PaginationQuery<GetAnnouncementWithPaginationDto> request,
        CancellationToken cancellationToken)
    {
        throw new NotImplementedException();
    }
}