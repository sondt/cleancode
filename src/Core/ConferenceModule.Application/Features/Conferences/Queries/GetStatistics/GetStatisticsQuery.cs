using MediatR;

namespace ConferenceModule.Application.Features.Conferences.Queries.GetStatistics;

public class GetStatisticsQuery : IRequest<IEnumerable<StatisticsDto>?> {
    public Guid ConferenceId { get; set; }
}