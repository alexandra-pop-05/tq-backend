using System;
using System.Collections.Generic;

namespace TQ_Project.Domain.Entities;

public partial class Document
{
    public int Id { get; set; }

    public string Name { get; set; } = null!;

    public string Purpose { get; set; } = null!;

    public string Link { get; set; } = null!;

    public int ProjectId { get; set; }

    public virtual Project Project { get; set; } = null!;
}
