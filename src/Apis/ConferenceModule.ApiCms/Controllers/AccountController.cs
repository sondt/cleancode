using ConferenceModule.Application.Common.Security;
using ConferenceModule.Application.Contracts.Accounts.AuthenticationModels;
using ConferenceModule.Application.Features.Accounts.Commands.Register;
using ConferenceModule.Application.Features.Accounts.Queries.Login;
using ConferenceModule.Domain;
using Microsoft.AspNetCore.Mvc;

namespace ConferenceModule.ApiCms.Controllers;

public class AccountController : ApiControllerBase {
    [HttpGet("get")]
    public ActionResult Get() {
        return Ok(SecurityHelper.EncryptSha1("sondang123"));
    }

    [HttpPost("login")]
    public async Task<AuthenticationResponse> Login(AuthenticationRequest request) {
        return await Mediator.Send(new LoginQuery {AuthenticationRequest = request});
    }

    [HttpPost("register")]
    public async Task<Account> Register(RegisterQuery request) {
        return await Mediator.Send(request);
    }
}