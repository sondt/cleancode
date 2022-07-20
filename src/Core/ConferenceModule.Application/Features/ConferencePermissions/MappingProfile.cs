using AutoMapper;
using ConferenceModule.Application.Features.ConferencePermissions.Commands.Create;
using ConferenceModule.Domain;

namespace ConferenceModule.Application.Features.ConferencePermissions;

public class MappingProfile : Profile {
    public MappingProfile() {
        CreateMap<CreateConferencePermissionCommand, ConferencePermission>();
    }
}