using System.Diagnostics.CodeAnalysis;
using ConferenceModule.Application.Common;
using ConferenceModule.Domain;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace ConferenceModule.Application.Features.Conferences.Queries.GetStatistics;

[SuppressMessage("ReSharper", "ComplexConditionExpression")]
public class GetStatisticsQueryHandler : IRequestHandler<GetStatisticsQuery, IEnumerable<StatisticsDto>?> {
    private readonly IRepositoryBase<Conference> _repository;

    public GetStatisticsQueryHandler(IRepositoryBase<Conference> repository) {
        _repository = repository;
    }

    // ReSharper disable once TooManyDeclarations
    public async Task<IEnumerable<StatisticsDto>?> Handle(GetStatisticsQuery request,
        CancellationToken cancellationToken) {
        var response = await _repository.FindByCondition(o => o.Id == request.ConferenceId).Select(x =>
            x.ConferenceDetails!.GroupBy(o => o.Status).Select(o => new StatisticsDto {
                Status = o.Key,
                Total = o.Count()
            })).ToListAsync(cancellationToken);

        return !response.Any() ? new List<StatisticsDto>() : response.First();
    }
}