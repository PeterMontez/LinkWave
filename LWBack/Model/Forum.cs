using System;
using System.Collections.Generic;

namespace LWBack.Model;

public partial class Forum
{
    public int ForumId { get; set; }

    public string Name { get; set; } = null!;

    public string Description { get; set; } = null!;

    public DateTime CreatedAt { get; set; }

    public virtual ICollection<ForumUser> ForumUsers { get; set; } = new List<ForumUser>();

    public virtual ICollection<Position> Positions { get; set; } = new List<Position>();

    public virtual ICollection<Post> Posts { get; set; } = new List<Post>();

    public virtual ICollection<Rating> Ratings { get; set; } = new List<Rating>();
}
