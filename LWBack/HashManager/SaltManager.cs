using System;
using System.Linq;

namespace LWBack.HashManager;

public static class SaltManager
{
    private static readonly Random random = new Random();
    private const string AllowedChars = "abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789!@#$^&*()+=<>?;:[]{}";

    public static string GetSalt(int length)
    {
        char[] result = new char[length];
        for (int i = 0; i < length; i++)
        {
            result[i] = AllowedChars[random.Next(AllowedChars.Length)];
        }
        return new string(result);
    }

    public static string AddSalt(string item, string salt)
    {
        return item + salt;
    }
}