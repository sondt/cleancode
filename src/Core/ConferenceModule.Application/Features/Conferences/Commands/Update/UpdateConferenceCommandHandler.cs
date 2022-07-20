using AutoMapper;
using ConferenceModule.Application.Common;
using ConferenceModule.Application.Common.Exceptions;
using ConferenceModule.Application.Common.Extensions;
using ConferenceModule.Application.Common.Services;
using ConferenceModule.Application.Contracts.Conferences;
using ConferenceModule.Domain;
using MediatR;

namespace ConferenceModule.Application.Features.Conferences.Commands.Update;

public class UpdateConferenceCommandHandler : IRequestHandler<UpdateConferenceCommand, Conference> {
    private readonly IConferenceRepository _exchangeRepository;
    private readonly IMapper _mapper;

    public UpdateConferenceCommandHandler(IConferenceRepository exchangeRepository, IMapper mapper) {
        _exchangeRepository = exchangeRepository;
        _mapper = mapper;
    }

    public async Task<Conference> Handle(UpdateConferenceCommand request, CancellationToken cancellationToken) {
        await Guard.Against.Validate(request.Conference, new UpdateConferenceValidation());

        var existed = await _exchangeRepository.GetAsync(new BaseRequest(request.Conference.Id, cancellationToken));
        if (existed == null) throw new NotFoundException(nameof(request.Conference), request.Conference.Id.ToString());

        var onlineExchange = _mapper.Map<Conference>(request.Conference);
        return await _exchangeRepository.UpdateAsync(onlineExchange, cancellationToken);
    }
}