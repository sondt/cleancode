using AutoMapper;
using ConferenceModule.Application.Features.Guests.Commands.Create;
using ConferenceModule.Application.Features.Guests.Commands.Update;
using ConferenceModule.Domain;

namespace ConferenceModule.Application.Features.Guests;

public class MappingProfile : Profile {
    public MappingProfile() {
        CreateMap<CreateGuestCommand, Guest>();
        CreateMap<UpdateGuestCommand, Guest>();
    }
}