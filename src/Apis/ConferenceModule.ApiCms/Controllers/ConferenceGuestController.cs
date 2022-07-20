using ConferenceModule.Application.Features.ConferenceGuests.Commands.Create;
using ConferenceModule.Application.Features.ConferenceGuests.Commands.Delete;
using ConferenceModule.Application.Features.ConferenceGuests.Commands.Update;
using ConferenceModule.Application.Features.ConferenceGuests.Queries.Get;
using Microsoft.AspNetCore.Mvc;

namespace ConferenceModule.ApiCms.Controllers;

public class ConferenceGuestController : ApiControllerBase {
    /// <summary>
    ///     Create a new guest
    /// </summary>
    /// <param name="command"></param>
    /// <returns></returns>
    [HttpPost("")]
    public async Task<ActionResult<int>> CreateGuest([FromBody] CreateConferenceGuestCommand command) {
        return Ok(await Mediator.Send(command));
    }

    /// <summary>
    ///     Update a guest
    /// </summary>
    /// <param name="id"></param>
    /// <param name="command"></param>
    /// <returns></returns>
    [HttpPut("{id:guid}")]
    public async Task<ActionResult<int>> UpdateGuest(Guid id, [FromBody] UpdateConferenceGuestCommand command) {
        command.SetId(id);
        return Ok(await Mediator.Send(command));
    }

    /// <summary>
    ///     Delete a guest
    /// </summary>
    /// <param name="id"></param>
    /// <returns></returns>
    [HttpDelete("{id:guid}")]
    public async Task<ActionResult<int>> DeleteConferenceGuest(Guid id) {
        return Ok(await Mediator.Send(new DeleteConferenceGuestCommand {Id = id}));
    }

    /// <summary>
    ///     Get a guest
    /// </summary>
    /// <param name="id"></param>
    /// <returns></returns>
    [HttpGet("{id:guid}")]
    public async Task<ActionResult> GetById(Guid id) {
        return ResponseObject(await Mediator.Send(new GetConferenceGuestQuery {Id = id}), id);
    }
}