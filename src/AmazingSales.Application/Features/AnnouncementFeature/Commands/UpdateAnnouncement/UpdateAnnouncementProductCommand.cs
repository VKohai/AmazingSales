using MediatR;
using AmazingSales.Domain.Entities.AnnouncementEntities;
using AmazingSales.Application.Interfaces.Repositories;

namespace AmazingSales.Application.Features.AnnouncementFeature.Commands.UpdateAnnouncement;

public record UpdateAnnouncementProductCommand(AnnouncementProduct AnnouncementProduct)
    : IRequest<AnnouncementProduct?>;

internal class UpdateAnnouncementProductCommandHandler :
    IRequestHandler<UpdateAnnouncementProductCommand, AnnouncementProduct?>
{
    private readonly IUnitOfWork _unitOfWork;

    public UpdateAnnouncementProductCommandHandler(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    public async Task<AnnouncementProduct?> Handle(UpdateAnnouncementProductCommand request,
        CancellationToken cancellationToken)
    {
        var updatedProduct = await
            _unitOfWork.Repository<AnnouncementProduct, long>().UpdateAsync(request.AnnouncementProduct);
        if (updatedProduct is null)
        {
            return null;
        }

        await _unitOfWork.Save(cancellationToken);
        return updatedProduct;
    }
}