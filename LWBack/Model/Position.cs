using System;
using System.Collections.Generic;

namespace LWBack.Model;

public partial class Position
{
    public int PositionId { get; set; }

    public string Name { get; set; }

    public int? ForumId { get; set; }

    public virtual Forum Forum { get; set; }

    public virtual ICollection<ForumUser> ForumUsers { get; set; } = new List<ForumUser>();

    public virtual ICollection<PosPerm> PosPerms { get; set; } = new List<PosPerm>();
}
