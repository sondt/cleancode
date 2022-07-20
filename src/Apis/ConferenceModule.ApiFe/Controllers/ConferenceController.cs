using ConferenceModule.ApiFe.Cache;
using ConferenceModule.Application.Features.ConferenceDetails.Queries.GetPublished;
using ConferenceModule.Application.Features.Conferences.Queries.GetGuestInConference;
using Microsoft.AspNetCore.Mvc;

namespace ConferenceModule.ApiFe.Controllers;

public class ConferenceController : ApiControllerBase {
    /// <summary>
    ///     Get all guests in conference
    /// </summary>
    /// <param name="id"></param>
    /// <returns></returns>
    [HttpGet("{id:guid}/guests")]
    [Cached(300)] // cache for 5 minutes
    public async Task<ActionResult> GetGuests(Guid id) {
        return ResponseList((await Mediator.Send(new GetGuestInConferenceQuery {ConferenceId = id}))!);
    }

    [HttpGet("{articleId:long}/guests")]
    public async Task<ActionResult> GetGuests(long articleId) {
        return ResponseList((await Mediator.Send(new GetGuestInConferenceQuery {ArticleId = articleId}))!);
    }

    [Cached(86400)] // cache for 1 day
    [HttpGet("{id:guid}/questions-answers")]
    public async Task<ActionResult> GetByStatus(Guid id) {
        var query = new GetByStatusQuery {ConferenceId = id};
        return Ok(await Mediator.Send(query));
    }
}