using System;
using System.Collections.Generic;

namespace TQ_Project.Domain.Entities;

public partial class Review
{
    public int Id { get; set; }

    public int UploadedById { get; set; }

    public DateTime UploadedOnDate { get; set; }

    public string FileName { get; set; } = null!;

    public int UserId { get; set; }

    public virtual User UploadedBy { get; set; } = null!;

    public virtual User User { get; set; } = null!;
}
