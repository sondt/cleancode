using ConferenceModule.Domain.Enums;

namespace ConferenceModule.Application.Features.Conferences.Queries.GetStatistics;

public class StatisticsDto {
    public ConferenceDetailStatus Status { get; set; }
    public int Total { get; set; }
}