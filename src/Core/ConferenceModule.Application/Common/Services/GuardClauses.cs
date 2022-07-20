namespace ConferenceModule.Application.Common.Services;

public interface IGuardClause {
}

public class Guard : IGuardClause {
    private Guard() {
    }

    /// <summary>
    ///     An entry point to a set of Guard Clauses.
    /// </summary>
    public static IGuardClause Against { get; } = new Guard();
}