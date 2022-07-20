using System.ComponentModel.DataAnnotations;

namespace ConferenceModule.Domain.Models;

public class FindBaseModel {
    public string? Keyword { get; set; }

    [Required]
    public int PageIndex { get; set; } = 1;

    [Required]
    public int PageSize { get; set; } = 10;
}