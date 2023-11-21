using MediatR;
using AmazingSales.Domain.Enums;
using AmazingSales.Domain.Entities.AnnouncementEntities;
using AmazingSales.Application.Interfaces.Repositories;

namespace AmazingSales.Application.Features.AnnouncementFeature.Commands;

public record DeleteAnnouncementByIdCommand(long Id, AnnouncementType AnnouncementType) : IRequest<Announcement?>;

internal class DeleteAnnouncementByIdCommandHandler : IRequestHandler<DeleteAnnouncementByIdCommand, Announcement?>
{
    private readonly IUnitOfWork _unitOfWork;

    public DeleteAnnouncementByIdCommandHandler(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    public async Task<Announcement?> Handle(DeleteAnnouncementByIdCommand request, CancellationToken cancellationToken)
    {
        // First delete certain type of announcement from DB
        // switch (request.AnnouncementType)
        // {
        //     case AnnouncementType.Products:
        //         await _unitOfWork.Repository<AnnouncementProduct, long>().DeleteByIdAsync(request.Id);
        //         break;
        //     case AnnouncementType.Services:
        //         await _unitOfWork.Repository<AnnouncementService, long>().DeleteByIdAsync(request.Id);
        //         break;
        //     default:
        //         throw new ArgumentException("Unknown type of announcement");
        // }

        var deletedAnnouncement = await _unitOfWork.Repository<Announcement, long>().DeleteByIdAsync(request.Id);
        if (deletedAnnouncement is null)
            return null;

        deletedAnnouncement.AddDomainEvent(new AnnouncementDeletedByIdEvent(deletedAnnouncement));
        await _unitOfWork.Save(cancellationToken);
        return deletedAnnouncement;
    }
}