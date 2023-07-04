using System;
using System.Collections.Generic;

namespace LWBack.Model;

public partial class User
{
    public int UserId { get; set; }

    public string Username { get; set; }

    public string Email { get; set; }

    public string PasswordHash { get; set; }

    public string Salt { get; set; }

    public string Picture { get; set; }

    public DateTime BirthDate { get; set; }

    public virtual ICollection<ForumUser> ForumUsers { get; set; } = new List<ForumUser>();

    public virtual ICollection<Post> Posts { get; set; } = new List<Post>();

    public virtual ICollection<Rating> Ratings { get; set; } = new List<Rating>();
}
