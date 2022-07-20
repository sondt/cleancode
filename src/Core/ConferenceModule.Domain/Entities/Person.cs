using System.ComponentModel.DataAnnotations.Schema;

namespace ConferenceModule.Domain; 


[Table("Person")]
public class Person {
    public int Id { get; set; }

    public string? Code { get; set; }

    public string? Name { get; set; }

    public List<Address>? Address { get; set; }
}


[Table("Address")]
public class Address {
    public int Id { get; set; }

    public string? XCode { get; set; }

    public string? Street { get; set; }
    
    public Person? Person { get; set; }
}