using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Cors;

using Security_jwt;

using LWBack.Model;
using LWBack.HashManager;
using LWBack.Data;
using LWBack.Services;

namespace LWBack.Controllers;

[ApiController]
[Route("posts")]
[EnableCors("MainPolicy")]
public class PostsController : ControllerBase
{

    [HttpPost("forum")]
    [EnableCors("MainPolicy")]
    public ActionResult Signin(
        [FromBody] Jwt token,
        [FromServices] IUserRepository repo,
        [FromServices] IJwtService jwtService)
    {

        System.Console.WriteLine(token.value);

        var result = jwtService.Validate<Jwt>(token.value);

        Console.WriteLine(result.value);

        // User newUser = new User();
        // newUser.Email = data.email;
        // newUser.Username = data.username;
        // newUser.Salt = SaltManager.GetSalt(16);
        // newUser.PasswordHash = Hasher.Hash(SaltManager.AddSalt(data.password, newUser.Salt));
        // newUser.BirthDate = data.birthdate;
        // newUser.Picture = data.picture;

        // if (repo.CheckNewUser(newUser).Result)
        // {
        //     repo.Create(newUser);
        //     return Ok();
        // }

        // else
        // {
        //     return BadRequest(repo.CheckNewUser(newUser).ReturnMsg);
        // }

        return Ok(result);

    }

    [HttpPost("login")]
    public async Task<ActionResult<Jwt>> Login(
        [FromBody] LoginData data,
        [FromServices] IUserRepository repo,
        [FromServices] IJwtService jwtService)
    {
        
        ReturnLoginData user = new ReturnLoginData
        {
            value = data.user
        };

        string jwt = jwtService.GetToken(user);

        if (repo.Validate(data))
        {
            return Ok(new Jwt() { value = jwt});
        }
        
        else
            return BadRequest("Invalid Username or Password");
    }

    // [HttpPost("subscribe")]
    // public ActionResult Subscribe(
    //     [FromBody] SubscribeData data,
    //     [FromServices] IUserRepository repo)
    // {
    //     return Ok(repo.Validate(data));
    // }

}