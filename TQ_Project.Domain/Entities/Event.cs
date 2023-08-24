using System;
using System.Collections.Generic;
using TQ_Project.Domain.Enums;

namespace TQ_Project.Domain.Entities;

public partial class Event
{
    public int Id { get; set; }

    public string EventName { get; set; } = null!;

    public EventType Type { get; set; } 

    public EventStatus Status { get; set; } 

    public DateTime FromDate { get; set; }

    public DateTime ToDate { get; set; }

    public string Description { get; set; } = null!;

    public virtual ICollection<UsersEvent> UsersEvents { get; set; } = new List<UsersEvent>();
}
