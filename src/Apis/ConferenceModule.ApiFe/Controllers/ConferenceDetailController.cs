using ConferenceModule.Application.Features.ConferenceDetails.Commands.CreateWithoutAccount;
using Microsoft.AspNetCore.Mvc;

namespace ConferenceModule.ApiFe.Controllers;

public class ConferenceDetailController : ApiControllerBase {
    [HttpPost("CreateWithoutAccount")]
    public async Task<ActionResult> CreateWithoutAccount(
        [FromBody] CreateConferenceDetailWithoutAccountCommand conferenceDetail) {
        return Ok(await Mediator.Send(conferenceDetail));
    }

    [HttpGet("demo")]
    public ActionResult Demo() {
        return Ok("demo");
    }
}