using ConferenceModule.Application.Contracts.Conferences;
using ConferenceModule.Application.Features.Persons.Queries;
using Microsoft.AspNetCore.Mvc;

namespace ConferenceModule.ApiCms.Controllers;

public class TestController : ApiControllerBase {
    private readonly IConferenceHub _conferenceHub;

    public TestController(IConferenceHub conferenceHub) {
        _conferenceHub = conferenceHub;
    }

    [HttpGet("test-relation")]
    public async Task<ActionResult> TestRelation([FromQuery] ConferenceResponse response) {
        //var result = await Mediator.Send(new PersonQuery());
        await _conferenceHub.PushConferenceToAllClientsAsync(response);
        return Ok("done");
    }
}