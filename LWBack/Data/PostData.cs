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