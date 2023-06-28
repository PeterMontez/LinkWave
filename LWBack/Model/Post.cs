using System;
using System.Collections.Generic;

namespace LWBack.Model;

public partial class Post
{
    public int PostId { get; set; }

    public string? Title { get; set; }

    public string? Content { get; set; }

    public string? Picture { get; set; }

    public int? UserId { get; set; }

    public int? ForumId { get; set; }

    public virtual Forum? Forum { get; set; }

    public virtual User? User { get; set; }
}
