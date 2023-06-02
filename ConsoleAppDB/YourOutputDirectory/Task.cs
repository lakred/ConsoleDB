using System;
using System.Collections.Generic;

namespace ConsoleAppDB.YourOutputDirectory;

public partial class Task
{
    public int Id { get; set; }

    public string? CardId { get; set; }

    public string? Title { get; set; }

    public string Description { get; set; } = null!;

    public bool IsUploaded { get; set; }

    public DateTime StartDate { get; set; }

    public DateTime? DueDate { get; set; }

    public int PriorityId { get; set; }

    public int StateId { get; set; }

    public virtual ICollection<Comment> Comments { get; set; } = new List<Comment>();

    public virtual ICollection<Partecipant> Partecipants { get; set; } = new List<Partecipant>();

    public virtual Priority Priority { get; set; } = null!;

    public virtual State State { get; set; } = null!;
}
