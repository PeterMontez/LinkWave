using System;

namespace LWBack.Data;

public class PostData
{
    public int postid { get; set; }
    public string title { get; set; }
    public string content { get; set; }
    public string picture { get; set; }
    public int userid { get; set; }
    public int forumid { get; set; }
}

public class PostDisplayData
{
    public string user { get; set; }
    public string forum { get; set; }
    public string title { get; set; }
    public string content { get; set; }
    public string picture { get; set; }
    public int likes { get; set; }
    public int dislikes { get; set; }
}