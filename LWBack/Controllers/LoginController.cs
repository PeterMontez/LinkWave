using Microsoft.AspNetCore.Mvc;
using LWBack.Model;
using LWBack.HashManager;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using Microsoft.AspNetCore.Cors;

namespace LWBack.Controllers;

[ApiController]
[Route("user")]
[EnableCors("MainPolicy")]
public class LoginController : ControllerBase
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


        // await repo.Create(newUser);
        // // result.Success = true;
        // // return Ok(result);
    }
}