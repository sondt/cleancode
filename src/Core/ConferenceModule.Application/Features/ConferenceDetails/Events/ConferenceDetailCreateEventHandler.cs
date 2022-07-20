using System.Diagnostics.CodeAnalysis;
using AutoMapper;
using ConferenceModule.Application.Common.Models;
using ConferenceModule.Application.Common.Services;
using ConferenceModule.Application.Common.Settings.Backend;
using ConferenceModule.Application.Contracts.Conferences;
using ConferenceModule.Domain.Enums;
using ConferenceModule.Domain.Events;
using MediatR;
using HttpMethod = ConferenceModule.Application.Common.Models.HttpMethod;

namespace ConferenceModule.Application.Features.ConferenceDetails.Events;

[SuppressMessage("ReSharper", "TooManyDependencies")]
public class ConferenceDetailCreateEventHandler : INotificationHandler<ConferenceDetailEvent> {
    private readonly IConferenceDetailRepository _conferenceDetailRepository;
    private readonly IConferenceHub _conferenceHub;
    private readonly IMapper _mapper;
    private readonly IHttpService _httpService;

    public ConferenceDetailCreateEventHandler(IConferenceHub conferenceHub, IMapper mapper,
        IConferenceDetailRepository conferenceDetailRepository, IHttpService httpService) {
        _conferenceHub = conferenceHub;
        _mapper = mapper;
        _conferenceDetailRepository = conferenceDetailRepository;
        _httpService = httpService;
    }

    public async Task Handle(ConferenceDetailEvent notification, CancellationToken cancellationToken) {
        if (notification.ConferenceDetail.Status is not (ConferenceDetailStatus.Published
            or ConferenceDetailStatus.Deleted)) return;

        var conference =
            await _conferenceDetailRepository.GetQuestionAnswerAsync(notification.ConferenceDetail.Id,
                CancellationToken.None);
        if (conference is null) return;
        
        var conferenceResponse = _mapper.Map<ConferenceResponse>(conference);
        var taskPushNotification = _conferenceHub.PushConferenceToAllClientsAsync(conferenceResponse);

        var taskQuestionAnswer = _httpService.ClearCacheAsync(new RequestModel(
            $"{ApiFrontend.BaseUrl}{string.Format(ApiFrontend.ConferenceQuestionAnswerPath, notification.ConferenceDetail.ConferenceId)}",
            HttpMethod.Get));

        await Task.WhenAll(taskPushNotification, taskQuestionAnswer).ConfigureAwait(false);
    }
}