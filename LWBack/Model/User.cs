using System;
using System.Collections.Generic;

namespace LWBack.Model;

public partial class User
{
    public int UserId { get; set; }

    public string Username { get; set; } = null!;

    public string Email { get; set; } = null!;

    public string PasswordHash { get; set; } = null!;

    public string Salt { get; set; } = null!;

    public string Picture { get; set; } = null!;

    public DateTime BirthDate { get; set; }

    public virtual ICollection<ForumUser> ForumUsers { get; set; } = new List<ForumUser>();

    public virtual ICollection<Post> Posts { get; set; } = new List<Post>();

    public virtual ICollection<Rating> Ratings { get; set; } = new List<Rating>();
}
