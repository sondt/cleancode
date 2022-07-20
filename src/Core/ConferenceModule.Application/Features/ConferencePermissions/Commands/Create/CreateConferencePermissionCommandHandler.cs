using System.Linq.Expressions;
using AutoMapper;
using ConferenceModule.Application.Common;
using ConferenceModule.Application.Common.Exceptions;
using ConferenceModule.Application.Common.Extensions;
using ConferenceModule.Application.Common.Message;
using ConferenceModule.Application.Common.Services;
using ConferenceModule.Domain;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace ConferenceModule.Application.Features.ConferencePermissions.Commands.Create;

public class
    CreateConferencePermissionCommandHandler : IRequestHandler<CreateConferencePermissionCommand,
        ConferencePermission> {
    private readonly IMapper _mapper;
    private readonly IRepositoryBase<ConferencePermission> _repository;

    public CreateConferencePermissionCommandHandler(IRepositoryBase<ConferencePermission> repository, IMapper mapper) {
        _repository = repository;
        _mapper = mapper;
    }

    public async Task<ConferencePermission> Handle(CreateConferencePermissionCommand request,
        CancellationToken cancellationToken) {
        await Guard.Against.Validate(request, new CreateConferencePermissionCommandValidation());

        //ReSharper disable once ComplexConditionExpression
        Expression<Func<ConferencePermission, bool>> condition = permission =>
            permission.UserId == request.UserId && permission.ConferenceId == request.ConferenceId;

        var existing = await _repository.FindByCondition(condition).AnyAsync(cancellationToken);
        if (existing) throw new BadRequestException(ConferencePermissionMessage.Existing);

        var conferencePermission = _mapper.Map<ConferencePermission>(request);
        conferencePermission.Id = Guid.NewGuid();
        conferencePermission.CreatedDate = DateTime.Now;

        return await _repository.CreateAsync(conferencePermission, cancellationToken);
    }
}