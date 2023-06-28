using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Cors;

using LWBack.Model;
using LWBack.HashManager;
using LWBack.Data;
using LWBack.Services;

namespace LWBack.Controllers;

[ApiController]
[Route("user")]
[EnableCors("MainPolicy")]
public class UserController : ControllerBase
{

    [HttpPost("signin")]
    public ActionResult Signin(
        [FromBody] SignInData data,
        [FromServices] IUserRepository repo)
    {
        User newUser = new User();
        newUser.Email = data.Email;
        newUser.Username = data.Username;
        newUser.Salt = SaltManager.GetSalt(16);
        newUser.PasswordHash = Hasher.Hash(SaltManager.AddSalt(data.Password, newUser.Salt));
        newUser.BirthDate = data.BirthDate;
        newUser.Picture = data.Picture;

        repo.Create(newUser);

        return Ok();
    }

    [HttpPost("login")]
    public ActionResult Login(
        [FromBody] LoginData data,
        [FromServices] IUserRepository repo)
    {
        repo.Validate(data);
    }

}