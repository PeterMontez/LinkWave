using System;

namespace LWBack.Data;

public class SignInCheckData
{
    public string Email { get; set; }
    public string Username { get; set; }
    public string ReturnMsg { get; set; }
    public bool Result { get; set; }
}