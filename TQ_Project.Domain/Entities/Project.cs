using System;
using System.Collections.Generic;
using TQ_Project.Domain.Enums;

namespace TQ_Project.Domain.Entities;

public partial class Project
{
    public int Id { get; set; }

    public string ProjectName { get; set; } = null!;

    public int? TeamManagerId { get; set; }

    public int? ProjectManagerId { get; set; }

    public ProjectStatus ProjectStatus { get; set; } 

    public DateTime StartDate { get; set; }

    public DateTime EndDate { get; set; }

    public string Client { get; set; } = null!;

    public string Description { get; set; } = null!;
    public virtual User? ProjectManager { get; set; } = null!;
    public virtual User? TeamManager { get; set; } = null!;

    public virtual ICollection<Document> Documents { get; set; } = new List<Document>();

    public virtual ICollection<KeyMilestone> KeyMilestones { get; set; } = new List<KeyMilestone>();


    public virtual ICollection<ProjectMember> ProjectMembers { get; set; } = new List<ProjectMember>();

}
