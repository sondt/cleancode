using ConferenceModule.Application.Contracts.Accounts.AuthenticationModels;
using MediatR;

namespace ConferenceModule.Application.Features.Accounts.Queries.Login;

public class LoginQuery : IRequest<AuthenticationResponse> {
    public AuthenticationRequest? AuthenticationRequest { get; set; }
}