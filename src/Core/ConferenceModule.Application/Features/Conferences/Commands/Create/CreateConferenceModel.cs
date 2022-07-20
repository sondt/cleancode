using System.ComponentModel.DataAnnotations;
using ConferenceModule.Domain.Enums;

namespace ConferenceModule.Application.Features.Conferences.Commands.Create;

public class CreateConferenceModel {
    [Required]
    public long NewsId { get; set; }

    [Required]
    public DateTime StartTime { get; set; }

    [Required]
    public DateTime EndTime { get; set; }

    [Required]
    public ConferenceStatus Status { get; set; }
}