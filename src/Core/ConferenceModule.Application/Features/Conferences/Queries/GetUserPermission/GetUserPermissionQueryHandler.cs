using AutoMapper;
using AutoMapper.QueryableExtensions;
using ConferenceModule.Application.Common;
using ConferenceModule.Domain;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace ConferenceModule.Application.Features.Conferences.Queries.GetUserPermission;

public class
    GetUserPermissionQueryHandler : IRequestHandler<GetUserPermissionQuery,
        IReadOnlyList<ConferenceUserPermissionDto>> {
    private readonly IMapper _mapper;
    private readonly IRepositoryBase<ConferencePermission> _repository;

    public GetUserPermissionQueryHandler(IRepositoryBase<ConferencePermission> repository, IMapper mapper) {
        _repository = repository;
        _mapper = mapper;
    }

    public async Task<IReadOnlyList<ConferenceUserPermissionDto>> Handle(GetUserPermissionQuery request,
        CancellationToken cancellationToken) {
        return await _repository
            .FindByCondition(permission =>
                permission.Conference!.Id == request.ConferenceId && permission.User!.IsActive == 1)
            .ProjectTo<ConferenceUserPermissionDto>(_mapper.ConfigurationProvider).ToListAsync(cancellationToken);
    }
}