using System;
using System.Collections.Generic;
using TQ_Project.Domain.Enums;

namespace TQ_Project.Domain.Entities;

public partial class KeyMilestone
{
    public int Id { get; set; }

    public string MilestoneName { get; set; } = null!;

    public KeyMilestoneStatus Status { get; set; } 

    public DateTime FromDate { get; set; }

    public DateTime ToDate { get; set; }

    public int ProjectId { get; set; }

    public virtual Project Project { get; set; } = null!;
}
