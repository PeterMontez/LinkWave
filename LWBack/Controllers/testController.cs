using Microsoft.AspNetCore.Mvc;
using LWBack.HashManager;
using LWBack.Model;

namespace LWBack.Controllers;

[ApiController]
[Route("test")]
public class TestController : ControllerBase
{
    [HttpGet]
    public string Get()
    {
        string salt = SaltManager.GetSalt(16);

        return Hasher.Hash(SaltManager.AddSalt("senha", salt)) + " " + salt;
        //return "Server is running...";
    }
}