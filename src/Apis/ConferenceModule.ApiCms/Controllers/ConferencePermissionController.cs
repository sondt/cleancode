using ConferenceModule.Application.Features.ConferencePermissions.Commands.Create;
using ConferenceModule.Application.Features.ConferencePermissions.Commands.Delete;
using Microsoft.AspNetCore.Mvc;

namespace ConferenceModule.ApiCms.Controllers;

public class ConferencePermissionController : ApiControllerBase {
    [HttpPost]
    public async Task<ActionResult> Create([FromBody] CreateConferencePermissionCommand command) {
        return Ok(await Mediator.Send(command));
    }

    [HttpDelete("{id:guid}")]
    public async Task<ActionResult> Delete(Guid id) {
        return Ok(await Mediator.Send(new DeleteConferencePermissionCommand {Id = id}));
    }
}