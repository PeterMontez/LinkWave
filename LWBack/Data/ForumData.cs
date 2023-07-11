using System;

namespace LWBack.Data;

public class NewForumData
{
    public string Name { get; set; }
    public string Description { get; set; }
    public DateTime CreatedAt { get; set; }
    public string Token { get; set; }
}

public class ForumSearchData
{
    public string name { get; set; }
    public string description { get; set; }
    public string followers { get; set; }
    public int id { get; set; }
}