using System;
using System.Collections.Generic;

namespace ConsoleAppDB.YourOutputDirectory;

public partial class Priority
{
    public int Id { get; set; }

    public string Label { get; set; } = null!;

    public string Color { get; set; } = null!;

    public virtual ICollection<Task> Tasks { get; set; } = new List<Task>();
}
