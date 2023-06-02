using System;
using System.Collections.Generic;

namespace ConsoleAppDB.YourOutputDirectory;

public partial class Partecipant
{
    public int Id { get; set; }

    public int ScientitId { get; set; }

    public int TaskId { get; set; }

    public virtual Task Task { get; set; } = null!;
}
