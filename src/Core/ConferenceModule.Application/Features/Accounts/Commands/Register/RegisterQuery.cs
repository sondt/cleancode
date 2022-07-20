using System.ComponentModel.DataAnnotations;
using ConferenceModule.Domain;
using MediatR;

namespace ConferenceModule.Application.Features.Accounts.Commands.Register;

public class RegisterQuery : IRequest<Account> {
    [DataType(DataType.EmailAddress)]
    [Required]
    public string? Email { get; set; }

    [Required]
    public string? UserName { get; set; }

    [Required]
    [DataType(DataType.Password)]
    public string? Password { get; set; }

    [DataType(DataType.Password)]
    [Required]
    public string? ConfirmPassword { get; set; }
}