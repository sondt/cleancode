using System.Diagnostics.CodeAnalysis;
using System.Net;
using ConferenceModule.Application.Common.Extensions;

namespace ConferenceModule.Application.Common.Models;

[SuppressMessage("ReSharper", "UnusedAutoPropertyAccessor.Global")]
public class ErrorDetail {
    public HttpStatusCode StatusCode { get; set; }
    public string? Message { get; set; }

    public string? TraceId { get; set; }

    public override string ToString() {
        return this.ToJson(true);
    }
}