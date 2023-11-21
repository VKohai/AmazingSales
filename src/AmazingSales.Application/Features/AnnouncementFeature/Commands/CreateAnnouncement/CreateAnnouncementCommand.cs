using MediatR;
using AmazingSales.Domain.Enums;
using AmazingSales.Domain.Entities;
using AmazingSales.Domain.Entities.BadgeProfile;
using AmazingSales.Domain.Entities.BadgeAnnouncement;
using AmazingSales.Application.Interfaces.Repositories;

namespace AmazingSales.Application.Features.AnnouncementFeature.Commands;

public record CreateAnnouncementCommand : IRequest<long>
{
    public string Header { get; set; }
    public string Description { get; set; }
    public decimal Price { get; set; }
    public bool Autopublishing { get; set; }
    public DateTime Created { get; set; }
    public PublicationStatus PublicationStatus { get; set; }
    public int Views { get; set; }
    public Category Category { get; set; }
    public Profile Profile { get; set; }
    public Address Address { get; set; }
    public AnnouncementType AnnouncementType { get; set; }
    public ContactMethod ContactMethod { get; set; }
}

internal class CreateAnnouncementCommandHandler : IRequestHandler<CreateAnnouncementCommand, long>
{
    private readonly IUnitOfWork _unitOfWork;

    public CreateAnnouncementCommandHandler(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    public async Task<long> Handle(CreateAnnouncementCommand request, CancellationToken cancellationToken)
    {
        var announcement = new Announcement(
            header: request.Header,
            description: request.Description,
            price: request.Price,
            publicationStatus: request.PublicationStatus,
            category: request.Category,
            profile: request.Profile,
            address: request.Address,
            announcementType: request.AnnouncementType,
            contactMethod: request.ContactMethod,
            autopublishing: request.Autopublishing
        );

        announcement = await _unitOfWork.Repository<Announcement, long>().AddAsync(announcement);
        announcement.AddDomainEvent(new AnnouncementCreatedEvent(announcement));
        await _unitOfWork.Save(cancellationToken);
        return announcement.Id;
    }
}