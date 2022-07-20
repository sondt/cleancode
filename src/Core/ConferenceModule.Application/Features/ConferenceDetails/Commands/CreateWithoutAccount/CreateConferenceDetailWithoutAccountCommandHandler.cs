using AutoMapper;
using ConferenceModule.Application.Common;
using ConferenceModule.Application.Common.Extensions;
using ConferenceModule.Application.Common.Services;
using ConferenceModule.Application.Contracts.Accounts;
using ConferenceModule.Domain;
using ConferenceModule.Domain.Enums;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace ConferenceModule.Application.Features.ConferenceDetails.Commands.CreateWithoutAccount;

public class
    CreateConferenceDetailWithoutAccountCommandHandler : IRequestHandler<CreateConferenceDetailWithoutAccountCommand,
        ConferenceDetail> {
    private readonly IAccountRepository _accountRepository;
    private readonly IMapper _mapper;
    private readonly IRepositoryBase<ConferenceDetail> _repository;

    public CreateConferenceDetailWithoutAccountCommandHandler(IMapper mapper,
        IRepositoryBase<ConferenceDetail> repository, IAccountRepository accountRepository) {
        _mapper = mapper;
        _repository = repository;
        _accountRepository = accountRepository;
    }

    public async Task<ConferenceDetail> Handle(CreateConferenceDetailWithoutAccountCommand request,
        CancellationToken cancellationToken) {
        await Guard.Against.Validate(request, new CreateConferenceDetailWithoutAccountCommandValidation());

        var account = await _accountRepository.FindByCondition(o => o.Email == request.QuestionerEmail)
            .FirstOrDefaultAsync(cancellationToken);
        if (account == null) {
            account = new Account {
                Status = AccountStatus.WaitingVerify, UserName = request.QuestionerName,
                Email = request.QuestionerEmail, CreatedDate = DateTime.Now, ModifiedDate = DateTime.Now
            };
            account = await _accountRepository.CreateAsync(account, cancellationToken);
        }

        var conferenceDetail = _mapper.Map<ConferenceDetail>(request);
        conferenceDetail.Id = Guid.NewGuid();
        conferenceDetail.CreatedDate = conferenceDetail.ModifiedDate = DateTime.Now;
        conferenceDetail.AccountId = account.Id;
        if (conferenceDetail.Status == ConferenceDetailStatus.Published) {
            conferenceDetail.PublishedBy = conferenceDetail.ModifiedBy;
            conferenceDetail.PublishedDate = DateTime.Now;
        }

        return await _repository.CreateAsync(conferenceDetail, cancellationToken);
    }
}