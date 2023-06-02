using System;
using System.Collections.Generic;

namespace ConsoleAppDB.YourOutputDirectory;

public partial class Member
{
    public int Id { get; set; }

    public string? CreatorId { get; set; }

    public int ScientistId { get; set; }

    public virtual Scientist Scientist { get; set; } = null!;
}
