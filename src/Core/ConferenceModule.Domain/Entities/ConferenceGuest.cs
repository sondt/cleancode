namespace ConferenceModule.Domain;

public class ConferenceGuest {
    public Guid Id { get; set; }
    public Guid ConferenceId { get; set; }
    public Guid GuestId { get; set; }

    //[NotMapped]
    public Guest? Guest { get; set; }

    //[NotMapped]
    public Conference? Conference { get; set; }
}