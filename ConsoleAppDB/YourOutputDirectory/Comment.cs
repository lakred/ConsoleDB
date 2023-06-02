using System;
using System.Collections.Generic;

namespace ConsoleAppDB.YourOutputDirectory;

public partial class Comment
{
    public int Id { get; set; }

    public string? CommentId { get; set; }

    public string Text { get; set; } = null!;

    public DateTime Date { get; set; }

    public int TaskId { get; set; }

    public virtual Task Task { get; set; } = null!;
}
