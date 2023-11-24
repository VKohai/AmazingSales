using MediatR;
using AmazingSales.Domain.Entities.Enums;
using AmazingSales.Domain.Entities.AnnouncementEntities;
using AmazingSales.Application.Interfaces.Repositories;

namespace AmazingSales.Application.Features.AnnouncementFeature.Commands;

public record CreateAnnouncementServiceCommand : IRequest<long>
{
    public Announcement Announcement { get; set; }
    public bool IsStartingPrice { get; set; }
    public PaymentPer PaymentPer { get; set; }
    public DateTime? StartTime { get; set; }
    public DateTime? EndTime { get; set; }
    public WorkDays WorkDays { get; set; }
}

[Obsolete("Never use this")]
internal class CreateAnnouncementServiceCommandHandler : IRequestHandler<CreateAnnouncementServiceCommand, long>
{
    private readonly IUnitOfWork _unitOfWork;

    public CreateAnnouncementServiceCommandHandler(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    public async Task<long> Handle(CreateAnnouncementServiceCommand request, CancellationToken cancellationToken)
    {
        var announcementService = new AnnouncementService(
            announcement: request.Announcement,
            paymentPer: request.PaymentPer,
            startTime: request.StartTime,
            endTime: request.EndTime,
            workDays: request.WorkDays,
            isStartingPrice: request.IsStartingPrice
        );

        await _unitOfWork.Repository<AnnouncementService, long>().AddAsync(announcementService);
        await _unitOfWork.Save(cancellationToken);

        return announcementService.Announcement.Id;
    }
}