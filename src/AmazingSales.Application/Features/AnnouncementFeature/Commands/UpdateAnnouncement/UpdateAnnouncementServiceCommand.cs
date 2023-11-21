using MediatR;
using AmazingSales.Domain.Entities.AnnouncementEntities;
using AmazingSales.Application.Interfaces.Repositories;

namespace AmazingSales.Application.Features.AnnouncementFeature.Commands.UpdateAnnouncement;

public record UpdateAnnouncementServiceCommand(AnnouncementService AnnouncementService)
    : IRequest<AnnouncementService?>;

internal class UpdateAnnouncementServiceCommandHandler :
    IRequestHandler<UpdateAnnouncementServiceCommand, AnnouncementService?>
{
    private readonly IUnitOfWork _unitOfWork;

    public UpdateAnnouncementServiceCommandHandler(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    public async Task<AnnouncementService?> Handle(UpdateAnnouncementServiceCommand request,
        CancellationToken cancellationToken)
    {
        var updatedService = await
            _unitOfWork.Repository<AnnouncementService, long>().UpdateAsync(request.AnnouncementService);
        if (updatedService is null)
        {
            return null;
        }

        await _unitOfWork.Save(cancellationToken);
        return updatedService;
    }
}