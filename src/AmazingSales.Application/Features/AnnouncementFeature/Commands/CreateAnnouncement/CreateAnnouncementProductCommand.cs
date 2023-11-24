using MediatR;
using AmazingSales.Domain.Enums;
using AmazingSales.Domain.Entities.AnnouncementEntities;
using AmazingSales.Application.Interfaces.Repositories;

namespace AmazingSales.Application.Features.AnnouncementFeature.Commands;

public record CreateAnnouncementProductCommand : IRequest<long>
{
    public Announcement Announcement { get; set; }
    public int Amount { get; set; }
    public ProductStatus ProductStatus { get; set; }
    public ProductSellingType ProductSellingType { get; set; }
}

[Obsolete("Never use this")]
internal class CreateAnnouncementProductCommandHandler : IRequestHandler<CreateAnnouncementProductCommand, long>
{
    private readonly IUnitOfWork _unitOfWork;

    public CreateAnnouncementProductCommandHandler(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    public async Task<long> Handle(CreateAnnouncementProductCommand request, CancellationToken cancellationToken)
    {
        var announcementProduct = new AnnouncementProduct(
            announcement: request.Announcement,
            request.Amount,
            request.ProductStatus,
            request.ProductSellingType
        );

        await _unitOfWork.Repository<AnnouncementProduct, long>().AddAsync(announcementProduct);
        await _unitOfWork.Save(cancellationToken);

        return announcementProduct.Announcement.Id;
    }
}