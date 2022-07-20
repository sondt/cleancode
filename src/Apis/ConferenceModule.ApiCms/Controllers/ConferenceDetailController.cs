using ConferenceModule.Application.Features.ConferenceDetails.Commands.Create;
using ConferenceModule.Application.Features.ConferenceDetails.Commands.CreateWithoutAccount;
using ConferenceModule.Application.Features.ConferenceDetails.Commands.Update;
using ConferenceModule.Application.Features.ConferenceDetails.Commands.UpdateStatus;
using ConferenceModule.Application.Features.ConferenceDetails.Queries.Get;
using Microsoft.AspNetCore.Mvc;

namespace ConferenceModule.ApiCms.Controllers;

public class ConferenceDetailController : ApiControllerBase {
    /// <summary>
    ///     Create a new conference detail
    /// </summary>
    /// <param name="conferenceDetail"></param>
    /// <returns></returns>
    [HttpPost]
    public async Task<ActionResult> Create([FromBody] CreateConferenceDetailCommand conferenceDetail) {
        return Ok(await Mediator.Send(conferenceDetail));
    }


    [HttpPost("CreateWithoutAccount")]
    public async Task<ActionResult> CreateWithoutAccount(
        [FromBody] CreateConferenceDetailWithoutAccountCommand conferenceDetail) {
        return Ok(await Mediator.Send(conferenceDetail));
    }

    [HttpPost("UpdateStatus")]
    public async Task<ActionResult> UpdateStatus([FromBody] UpdateStatusConferenceDetailCommand command) {
        return Ok(await Mediator.Send(command));
    }

    /// <summary>
    ///     Update a conference detail
    /// </summary>
    /// <param name="conferenceDetail"></param>
    /// <returns></returns>
    [HttpPut]
    public async Task<ActionResult> Update([FromBody] UpdateConferenceDetailCommand conferenceDetail) {
        return Ok(await Mediator.Send(conferenceDetail));
    }

    /// <summary>
    ///     Get a conference detail by id
    /// </summary>
    /// <param name="id"></param>
    /// <returns></returns>
    [HttpGet("{id:guid}")]
    public async Task<ActionResult> GetById(Guid id) {
        return ResponseObject(await Mediator.Send(new GetConferenceDetailQuery {Id = id}), id);
    }
}