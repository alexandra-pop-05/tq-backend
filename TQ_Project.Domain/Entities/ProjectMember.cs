using System;
using System.Collections.Generic;

namespace TQ_Project.Domain.Entities;
public partial class ProjectMember
{
    public int Id { get; set; }

    public int UserId { get; set; }

    public int ProjectId { get; set; }

    public virtual Project Project { get; set; } = null!;

    public virtual User User { get; set; } = null!;
}
