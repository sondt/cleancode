using AutoMapper;
using ConferenceModule.Application.Features.Conferences.Commands.Create;
using ConferenceModule.Application.Features.Conferences.Commands.Update;
using ConferenceModule.Application.Features.Conferences.Queries.Get;
using ConferenceModule.Application.Features.Conferences.Queries.GetGuestInConference;
using ConferenceModule.Application.Features.Conferences.Queries.GetUserPermission;
using ConferenceModule.Application.Features.Conferences.Queries.Paged;
using ConferenceModule.Domain;

namespace ConferenceModule.Application.Features.Conferences;

public class MappingProfiles : Profile {
    public MappingProfiles() {
        CreateMap<CreateConferenceModel, Conference>();
        CreateMap<UpdateConferenceModel, Conference>();
        CreateMap<GetConferenceModel, Conference>();

        CreateMap<Conference, ConferencePagedModel>().ForMember(x => x.Title, opt => opt.MapFrom(x => x.Article!.Title))
            .ForMember(x => x.Avatar, opt => opt.MapFrom(x => x.Article!.Avatar))
            .ForMember(x => x.GuestCount, opt => opt.MapFrom(x => x.ConferenceGuests!.Count()))
            .ForMember(x => x.ArticleId, opt => opt.MapFrom(x => x.Article!.Id.ToString()))
            .ForMember(x => x.EditorCount, opt => opt.MapFrom(x => x.ConferencePermissions!.Count()))
            .ForMember(x => x.QuestionCount, opt => opt.MapFrom(x => x.ConferenceDetails!.Count()));

        CreateMap<ConferencePermission, ConferenceUserPermissionDto>()
            .ForMember(x => x.FullName, opt => opt.MapFrom(x => x.User!.FullName))
            .ForMember(x => x.UserName, opt => opt.MapFrom(x => x.User!.UserName))
            .ForMember(x => x.ConferencePermissionId, opt => opt.MapFrom(x => x.Id));

        CreateMap<ConferenceGuest, GuestInConferenceDto>()
            .ForMember(x => x.Avatar, opt => opt.MapFrom(x => x.Guest!.Avatar))
            .ForMember(x => x.Title, opt => opt.MapFrom(x => x.Guest!.Title))
            .ForMember(x => x.Name, opt => opt.MapFrom(x => x.Guest!.Name))
            .ForMember(x => x.GuestId, opt => opt.MapFrom(x => x.GuestId))
            .ForMember(x => x.ConferenceGuestId, opt => opt.MapFrom(x => x.Id));
    }
}