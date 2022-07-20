using ConferenceModule.Domain.Models;
using MediatR;

namespace ConferenceModule.Application.Features.Conferences.Queries.Paged;

public class GetConferencePagedQuery : FindBaseModel, IRequest<PagedResult<ConferencePagedModel>> {
}