using System;
using System.Collections.Generic;

namespace ConsoleAppDB.YourOutputDirectory;

public partial class Scientist
{
    public int Id { get; set; }

    public string GivenName { get; set; } = null!;

    public string FamilyName { get; set; } = null!;

    public DateTime Birthday { get; set; }

    public virtual Member? Member { get; set; }
}
