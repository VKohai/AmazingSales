using MediatR;
using AmazingSales.Domain.Entities.BadgeAnnouncement;
using AmazingSales.Application.Interfaces.Repositories;

namespace AmazingSales.Application.Features.AnnouncementFeature.Commands.UpdateAnnouncement;

public record UpdateAnnouncementCommand(Announcement Announcement) : IRequest<Announcement?>;

public class UpdateAnnouncementCommandHandler : IRequestHandler<UpdateAnnouncementCommand, Announcement?>
{
    private readonly IUnitOfWork _unitOfWork;

    public UpdateAnnouncementCommandHandler(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    public async Task<Announcement?> Handle(UpdateAnnouncementCommand request, CancellationToken cancellationToken)
    {
        var updatedAnnouncement = await _unitOfWork.Repository<Announcement, long>().UpdateAsync(request.Announcement);
        if (updatedAnnouncement is null)
            return null;

        updatedAnnouncement.AddDomainEvent(new AnnouncementUpdatedByIdEvent(updatedAnnouncement));
        await _unitOfWork.Save(cancellationToken);
        return updatedAnnouncement;
    }
}