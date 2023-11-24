using MediatR;
using AutoMapper;
using AmazingSales.Domain.Enums;
using AmazingSales.Application.Interfaces.Repositories;
using AmazingSales.Domain.Entities.AnnouncementEntities;

namespace AmazingSales.Application.Features.AnnouncementFeature.Queries;

public record GetAnnouncementByIdQuery(long Id) : IRequest<GetAnnouncementByIdDto>;

public class GetAnnouncementByIdQueryHandler : IRequestHandler<GetAnnouncementByIdQuery, GetAnnouncementByIdDto>
{
    private readonly IMapper _mapper;
    private readonly IUnitOfWork _unitOfWork;

    public GetAnnouncementByIdQueryHandler(IUnitOfWork unitOfWork, IMapper mapper)
    {
        _unitOfWork = unitOfWork;
        _mapper = mapper;
    }

    public async Task<GetAnnouncementByIdDto> Handle(
        GetAnnouncementByIdQuery request,
        CancellationToken cancellationToken)
    {
        var announcement = await _unitOfWork.Repository<Announcement, long>().GetByIdAsync(request.Id);

        var announcmentDto = _mapper.Map<GetAnnouncementByIdDto>(announcement);
        return announcmentDto;
    }
}