using AmazingSales.Domain.Enums;
using AmazingSales.Domain.Entities;
using AmazingSales.Domain.Entities.ProfileEntities;
using AmazingSales.Domain.Entities.AnnouncementEntities;

namespace AmazingSales.Application.Features.AnnouncementFeature.Queries;

public class GetAnnouncementByIdDto
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
    public AnnouncementProduct? AnnouncementProduct { get; set; } = null;
    public AnnouncementService? AnnouncementService { get; set; } = null;
}