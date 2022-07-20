namespace ConferenceModule.ApiFe.Cache;

public class RedisCacheSettings {
    public bool Enabled { get; set; }

    public string? ConnectionString { get; set; }
}