using MediatR;
using AmazingSales.Application.Interfaces.Repositories;
using AmazingSales.Domain.Entities.AnnouncementEntities;
using AmazingSales.Domain.Enums;
using AutoMapper;

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

        AnnouncementProduct? product = null;
        AnnouncementService? service = null;

        switch (announcement.AnnouncementType)
        {
            case AnnouncementType.Products:
                product = await _unitOfWork.Repository<AnnouncementProduct, long>().GetByIdAsync(request.Id);
                break;
            case AnnouncementType.Services:
                service = await _unitOfWork.Repository<AnnouncementService, long>().GetByIdAsync(request.Id);
                break;
            default:
                throw new ArgumentException("Wrong type of announcement");
        }

        var announcmentDto = _mapper.Map<GetAnnouncementByIdDto>(announcement);
        announcmentDto.AnnouncementProduct = product;
        announcmentDto.AnnouncementService = service;
        return announcmentDto;
    }
}