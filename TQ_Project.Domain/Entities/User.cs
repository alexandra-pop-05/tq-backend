using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using TQ_Project.Domain.Enums;

namespace TQ_Project.Domain.Entities;
public partial class User
{
    public int Id { get; set; }

    public string Email { get; set; } = null!;

    public string Nickname { get; set; } = null!;

    public string Password { get; set; } = null!;

    public DateTime Birthday { get; set; }

    public UserRole Role { get; set; }

    public Levels Levels { get; set; } 

    public AuthRole Type { get; set; } 

    public string Phone { get; set; } = null!;

    public string City { get; set; } = null!;

    public DateTime JoinedAt { get; set; }

    public int FreeDaysLeft { get; set; }

    public byte[]? Photo { get; set; }

    public virtual ICollection<ProjectMember> ProjectMembers { get; set; } = new List<ProjectMember>();

    //public virtual ICollection<Project> ProjectProjectManagers { get; set; } = new List<Project>();

    //public virtual ICollection<Project> ProjectTeamManagers { get; set; } = new List<Project>();

     public virtual ICollection<Review> UploadedReviews { get; set; } = new List<Review>();

     public virtual ICollection<Review> ReceivedReviews { get; set; } = new List<Review>();

    /*  public virtual ICollection<Review> Reviews { get; set; } = new List<Review>();*/
    public virtual ICollection<UsersEvent> UsersEvents { get; set; } = new List<UsersEvent>();
}
