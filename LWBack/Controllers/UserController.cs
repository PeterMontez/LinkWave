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

        if (repo.CheckNewUser(newUser).Result)
        {
            repo.Create(newUser);
            return Ok();
        }

        else
        {
            return BadRequest(repo.CheckNewUser(newUser).ReturnMsg);
        }

    }

    [HttpPost("login")]
    public ActionResult Login(
        [FromBody] LoginData data,
        [FromServices] IUserRepository repo)
    {
        return Ok(repo.Validate(data));
    }

    // [HttpPost("subscribe")]
    // public ActionResult Subscribe(
    //     [FromBody] SubscribeData data,
    //     [FromServices] IUserRepository repo)
    // {
    //     return Ok(repo.Validate(data));
    // }

}