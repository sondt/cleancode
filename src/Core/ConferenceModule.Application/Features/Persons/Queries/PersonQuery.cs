using ConferenceModule.Application.Common;
using ConferenceModule.Domain;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace ConferenceModule.Application.Features.Persons.Queries; 

public class PersonQuery: IRequest<int> {
    
}

class PersonQueryHandler : IRequestHandler<PersonQuery, int> {
    private readonly IRepositoryBase<Person> _personRepository;
    private readonly IRepositoryBase<Address> _addressRepository;

    public PersonQueryHandler(IRepositoryBase<Person> personRepository, IRepositoryBase<Address> addressRepository) {
        _personRepository = personRepository;
        _addressRepository = addressRepository;
    }

    public async Task<int> Handle(PersonQuery request, CancellationToken cancellationToken) {

        for (int i = 0; i < 2; i++) {
           await _addressRepository.CreateAsync(new Address {
                Street = DateTime.Now.Ticks.ToString(), XCode = "p1"
            }, cancellationToken);
        }

        
        var query = await _addressRepository.FindByCondition(o => o.Person!.Code == "p1")
            .Select(o => new {Name = o.Person!.Name, Address = o.Street})
            .ToListAsync(cancellationToken);
        
        // var query = await _personRepository.FindByCondition(o => o.Address.XCode == "p1")
        //     .Select(o => new {Name = o.Name, Street = o.Address!.Street}).ToListAsync(cancellationToken);
        //
         return query.Count;
    }
}