using ConferenceModule.Application.Features.Guests.Commands.Create;
using ConferenceModule.Application.Features.Guests.Commands.Delete;
using ConferenceModule.Application.Features.Guests.Commands.Update;
using ConferenceModule.Application.Features.Guests.Queries.Get;
using ConferenceModule.Application.Features.Guests.Queries.GetGuestByStatus;
using Microsoft.AspNetCore.Mvc;

namespace ConferenceModule.ApiCms.Controllers;

public class GuestController : ApiControllerBase {
    /// <summary>
    ///     Create a new guest
    /// </summary>
    /// <param name="command"></param>
    /// <returns></returns>
    [HttpPost("")]
    public async Task<ActionResult> Create([FromBody] CreateGuestCommand command) {
        return Ok(await Mediator.Send(command));
    }

    /// <summary>
    ///     Update a guest
    /// </summary>
    /// <param name="command"></param>
    /// <returns></returns>
    [HttpPut]
    public async Task<ActionResult> Update([FromBody] UpdateGuestCommand command) {
        return Ok(await Mediator.Send(command));
    }

    /// <summary>
    ///     Delete a guest
    /// </summary>
    /// <param name="id"></param>
    /// <returns></returns>
    [HttpDelete("{id:guid}")]
    public async Task<ActionResult> Delete(Guid id) {
        return Ok(await Mediator.Send(new DeleteGuestCommand {Id = id}));
    }

    /// <summary>
    ///     Get a guest
    /// </summary>
    /// <param name="id"></param>
    /// <returns></returns>
    [HttpGet("{id:guid}")]
    public async Task<ActionResult> GetById(Guid id) {
        var guest = await Mediator.Send(new GetGuestQuery {Id = id});
        return ResponseObject(guest, id);
    }

    [HttpGet("filter")]
    public async Task<ActionResult> GetByFilter([FromQuery] GetGuestByStatusQuery query) {
        return ResponsePagedList(await Mediator.Send(query));
    }
}