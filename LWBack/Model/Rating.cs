using System;
using System.Collections.Generic;

namespace LWBack.Model;

public partial class Rating
{
    public int RatingId { get; set; }

    public bool? Rating1 { get; set; }

    public int? UserId { get; set; }

    public int? PostId { get; set; }

    public virtual Post Post { get; set; }

    public virtual User User { get; set; }
}
