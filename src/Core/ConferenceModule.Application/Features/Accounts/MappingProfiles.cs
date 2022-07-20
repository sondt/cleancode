using AutoMapper;
using ConferenceModule.Application.Features.Accounts.Commands.Register;
using ConferenceModule.Domain;

namespace ConferenceModule.Application.Features.Accounts;

public class MappingProfiles : Profile {
    public MappingProfiles() {
        CreateMap<RegisterQuery, Account>();
    }
}