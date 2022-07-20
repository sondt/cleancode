using AutoMapper;
using ConferenceModule.Application.Contracts.Conferences;
using ConferenceModule.Application.Features.ConferenceDetails.Commands.Create;
using ConferenceModule.Application.Features.ConferenceDetails.Commands.Update;
using ConferenceModule.Application.Features.ConferenceDetails.Queries.GetByStatus.Models;
using ConferenceModule.Domain;

namespace ConferenceModule.Application.Features.ConferenceDetails;

public class MappingProfile : Profile {
    public MappingProfile() {
        CreateMap<CreateConferenceDetailCommand, ConferenceDetail>();
        CreateMap<UpdateConferenceDetailCommand, ConferenceDetail>();


        CreateMap<Guest, Respondent>().ReverseMap();
        CreateMap<Account, Questioner>().ReverseMap();

        CreateMap<ConferenceDetail, QuestionAnswerDto>().ForMember(x => x.GuestId, opt => opt.MapFrom(x => x.GuestId))
            .ForMember(x => x.Questioner, opt => opt.MapFrom(x => x.Account))
            .ForMember(x => x.Respondent, opt => opt.MapFrom(x => x.Guest))
            .ForMember(x => x.EditorName, opt => opt.MapFrom(x => x.Editor!.FullName));

        CreateMap<QuestionAnswerDto, ConferenceResponse>();

        //mapping question and answer to conference published
        CreateMap<Guest, Queries.GetPublished.Models.Respondent>().ReverseMap();
        CreateMap<Account, Queries.GetPublished.Models.Questioner>().ReverseMap();

        CreateMap<ConferenceDetail, Queries.GetPublished.Models.QuestionAnswerDto>()
            .ForMember(x => x.Questioner, opt => opt.MapFrom(x => x.Account))
            .ForMember(x => x.Respondent, opt => opt.MapFrom(x => x.Guest));

        CreateMap<Queries.GetPublished.Models.QuestionAnswerDto, ConferenceResponse>();
    }
}