using System;
using System.Collections.Generic;

namespace ConsoleAppDB.YourOutputDirectory;

public partial class State
{
    public int Id { get; set; }

    public string? ListId { get; set; }

    public string Name { get; set; } = null!;

    public virtual ICollection<Task> Tasks { get; set; } = new List<Task>();
}
