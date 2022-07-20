using AutoMapper;
using ConferenceModule.Domain;

namespace ConferenceModule.Application.Features.ConferenceDetails.Commands.CreateWithoutAccount;

public class MappingProfile : Profile {
    public MappingProfile() {
        CreateMap<CreateConferenceDetailWithoutAccountCommand, ConferenceDetail>();
    }
}