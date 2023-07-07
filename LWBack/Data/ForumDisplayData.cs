using System;

namespace LWBack.Data;

public class ForumDisplayData
{
    public string name { get; set; }
    public int id { get; set; }
}

public class ForumCardData
{
    public string name { get; set; }
    public string createdat { get; set; }
    public string description { get; set; }
    public string position { get; set; }
    public int followers { get; set; }
}