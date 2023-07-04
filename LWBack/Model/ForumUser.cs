using System;
using System.Collections.Generic;

namespace LWBack.Model;

public partial class ForumUser
{
    public int AssociationId { get; set; }

    public int? UserId { get; set; }

    public int? ForumId { get; set; }

    public virtual Forum Forum { get; set; }

    public virtual User User { get; set; }
}
