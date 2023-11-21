using MediatR;
using AmazingSales.Domain.Entities.BadgeAnnouncement;
using AmazingSales.Application.Interfaces.Repositories;

namespace AmazingSales.Application.Features.AnnouncementFeature.Commands;

public record DeleteAnnouncementByIdCommand(long Id) : IRequest<Announcement?>;

internal class DeleteAnnouncementByIdCommandHandler : IRequestHandler<DeleteAnnouncementByIdCommand, Announcement?>
{
    private readonly IUnitOfWork _unitOfWork;

    public DeleteAnnouncementByIdCommandHandler(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    public async Task<Announcement?> Handle(DeleteAnnouncementByIdCommand request, CancellationToken cancellationToken)
    {
        var deletedAnnouncement = await _unitOfWork.Repository<Announcement, long>().DeleteByIdAsync(request.Id);
        if (deletedAnnouncement is null)
            return null;

        deletedAnnouncement.AddDomainEvent(new AnnouncementDeletedByIdEvent(deletedAnnouncement));
        await _unitOfWork.Save(cancellationToken);
        return deletedAnnouncement;
    }
}