using MediatR;
using AmazingSales.Domain.Entities.BadgeAnnouncement;
using AmazingSales.Application.Interfaces.Repositories;

namespace AmazingSales.Application.Features.AnnouncementFeature.Commands.UpdateAnnouncement;

public record UpdateAnnouncementByIdCommand(long Id) : IRequest<Announcement?>;

public class UpdateAnnouncementByIdCommandHandler : IRequestHandler<UpdateAnnouncementByIdCommand, Announcement?>
{
    private readonly IUnitOfWork _unitOfWork;

    public UpdateAnnouncementByIdCommandHandler(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    public async Task<Announcement?> Handle(UpdateAnnouncementByIdCommand request, CancellationToken cancellationToken)
    {
        var updatedAnnouncement = await _unitOfWork.Repository<Announcement, long>().UpdateByIdAsync(request.Id);
        if (updatedAnnouncement is null)
            return null;

        updatedAnnouncement.AddDomainEvent(new AnnouncementUpdatedByIdEvent(updatedAnnouncement));
        await _unitOfWork.Save(cancellationToken);
        return updatedAnnouncement;
    }
}