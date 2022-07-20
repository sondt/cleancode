using AutoMapper;
using ConferenceModule.Application.Features.ConferenceGuests.Commands.Create;
using ConferenceModule.Application.Features.ConferenceGuests.Commands.Update;
using ConferenceModule.Domain;

namespace ConferenceModule.Application.Features.ConferenceGuests;

public class MappingProfile : Profile {
    public MappingProfile() {
        CreateMap<CreateConferenceGuestCommand, ConferenceGuest>();
        CreateMap<UpdateConferenceGuestCommand, ConferenceGuest>();
    }
}