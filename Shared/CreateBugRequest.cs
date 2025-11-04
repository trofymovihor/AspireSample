using System;
using System.ComponentModel.DataAnnotations;

namespace Shared;

public class CreateBugRequest : NServiceBus.IMessage
{
    [Required]
    public string Title { get; set; } = string.Empty;

    [Required]
    public string Description { get; set; } = string.Empty;
    public string StepsToReproduce { get; set; } = string.Empty;
}
