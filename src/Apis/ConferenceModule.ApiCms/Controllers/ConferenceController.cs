using ConferenceModule.Application.Features.ConferenceDetails.Queries.GetByStatus;
using ConferenceModule.Application.Features.Conferences.Commands.Create;
using ConferenceModule.Application.Features.Conferences.Commands.Delete;
using ConferenceModule.Application.Features.Conferences.Commands.Update;
using ConferenceModule.Application.Features.Conferences.Queries.Get;
using ConferenceModule.Application.Features.Conferences.Queries.GetGuestInConference;
using ConferenceModule.Application.Features.Conferences.Queries.GetStatistics;
using ConferenceModule.Application.Features.Conferences.Queries.GetUserPermission;
using ConferenceModule.Application.Features.Conferences.Queries.Paged;
using Microsoft.AspNetCore.Mvc;

namespace ConferenceModule.ApiCms.Controllers;

public class ConferenceController : ApiControllerBase {
    /// <summary>
    ///     Create online exchange object
    /// </summary>
    /// <param name="createConferenceModel"></param>
    /// <returns></returns>
    [HttpPost]
    public async Task<ActionResult<int>> Create([FromBody] CreateConferenceModel createConferenceModel) {
        return Ok(await Mediator.Send(new CreateConferenceCommand {CreateConferenceModel = createConferenceModel}));
    }

    /// <summary>
    ///     Update online exchange object
    /// </summary>
    /// <param name="conference"></param>
    /// <returns></returns>
    [HttpPut]
    public async Task<ActionResult<int>> Update([FromBody] UpdateConferenceModel conference) {
        return Ok(await Mediator.Send(new UpdateConferenceCommand {Conference = conference}));
    }


    /// <summary>
    ///     Delete online exchange object
    /// </summary>
    /// <param name="id"></param>
    /// <returns></returns>
    [HttpDelete("{id:guid}")]
    public async Task<ActionResult<int>> Update(Guid id) {
        return Ok(await Mediator.Send(new DeleteConferenceCommand {Id = id}));
    }

    /// <summary>
    ///     Get by id
    /// </summary>
    /// <param name="id"></param>
    /// <returns></returns>
    [HttpGet("{id:guid}")]
    public async Task<ActionResult<GetConferenceModel?>> GetById(Guid id) {
        return ResponseObject(await Mediator.Send(new GetConferenceQuery {Id = id}), id);
    }

    [HttpGet("filter")]
    public async Task<ActionResult> Page([FromQuery] GetConferencePagedQuery query) {
        return Ok(await Mediator.Send(query));
    }

    /// <summary>
    ///     Get user permission in conference
    /// </summary>
    /// <param name="id"></param>
    /// <returns></returns>
    [HttpGet("{id:guid}/editors")]
    public async Task<ActionResult> GetEditors(Guid id) {
        return Ok(await Mediator.Send(new GetUserPermissionQuery {ConferenceId = id}));
    }

    /// <summary>
    ///     Get all guests in conference
    /// </summary>
    /// <param name="id"></param>
    /// <returns></returns>
    [HttpGet("{id:guid}/guests")]
    public async Task<ActionResult> GetGuests(Guid id) {
        return ResponseList((await Mediator.Send(new GetGuestInConferenceQuery {ConferenceId = id}))!);
    }

    [HttpGet("{id:guid}/questions-answers")]
    public async Task<ActionResult> GetByStatus(Guid id, [FromQuery] GetByStatusQuery query) {
        query.ConferenceId = id;
        return Ok(await Mediator.Send(query));
    }

    [HttpGet("{id:guid}/statistics")]
    public async Task<ActionResult> GetStatistics(Guid id) {
        return Ok(await Mediator.Send(new GetStatisticsQuery {ConferenceId = id}));
    }
}