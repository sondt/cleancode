using AutoMapper;
using AutoMapper.QueryableExtensions;
using ConferenceModule.Application.Contracts.Conferences;
using ConferenceModule.Application.Features.ConferenceDetails.Queries.GetByStatus.Models;
using ConferenceModule.Domain;
using Microsoft.EntityFrameworkCore;

namespace ConferenceModule.SqlPersistence.ConferenceDetails;

//RepositoryBase<Conference>, IConferenceRepository
public class ConferenceDetailRepository : RepositoryBase<ConferenceDetail>, IConferenceDetailRepository {
    private readonly IMapper _mapper;

    public ConferenceDetailRepository(MediaContext mediaContext, IMapper mapper) : base(mediaContext) {
        _mapper = mapper;
    }

    public async Task<QuestionAnswerDto?> GetQuestionAnswerAsync(Guid conferenceDetailId,
        CancellationToken cancellationToken) {
        return await FindByCondition(o => o.Id == conferenceDetailId)
            .ProjectTo<QuestionAnswerDto>(_mapper.ConfigurationProvider).FirstOrDefaultAsync(cancellationToken);
    }
}