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
[Route("user")]
[EnableCors("MainPolicy")]
public class UserController : ControllerBase
{

    [HttpPost("signin")]
    [EnableCors("MainPolicy")]
    public ActionResult Signin(
        [FromBody] SignInData data,
        [FromServices] IUserRepository repo)
    {
        User newUser = new User();
        newUser.Email = data.email;
        newUser.Username = data.username;
        newUser.Salt = SaltManager.GetSalt(16);
        newUser.PasswordHash = Hasher.Hash(SaltManager.AddSalt(data.password, newUser.Salt));
        newUser.BirthDate = data.birthdate;
        newUser.Picture = data.picture;

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
    public async Task<ActionResult<Jwt>> Login(
        [FromBody] LoginData data,
        [FromServices] IUserRepository repo,
        [FromServices] IJwtService jwtService)
    {

        string tempUserId = "0";

        if (repo.FindByName(data.user) == null)
        {
            if (repo.FindByEmail(data.user) != null)
            {
                tempUserId = repo.FindByEmail(data.user).UserId.ToString();
            }
        }
        else
        {
            tempUserId = repo.FindByName(data.user).UserId.ToString();
        }

        if (repo.Validate(data))
        {
            ReturnLoginData user = new()
            {
                value = tempUserId ?? "0"
            };

            string jwt = jwtService.GetToken(user);

            Jwt fullResponse = new()
            {
                value = jwt,
                id = int.Parse(user.value)
            };
            return Ok(fullResponse);
        }

        else
            return BadRequest("Invalid Username or Password");
    }

    [HttpPost("subscribe")]
    [EnableCors("MainPolicy")]
    public ActionResult Subscribe(
        [FromBody] SignInData data,
        [FromServices] IUserRepository repo)
    {
        User newUser = new User();
        newUser.Email = data.email;
        newUser.Username = data.username;
        newUser.Salt = SaltManager.GetSalt(16);
        newUser.PasswordHash = Hasher.Hash(SaltManager.AddSalt(data.password, newUser.Salt));
        newUser.BirthDate = data.birthdate;
        newUser.Picture = data.picture;

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

    [HttpPost("like")]
    [EnableCors("MainPolicy")]
    public ActionResult like(
        [FromBody] SignInData data,
        [FromServices] IUserRepository repo)
    {
        User newUser = new User();
        newUser.Email = data.email;
        newUser.Username = data.username;
        newUser.Salt = SaltManager.GetSalt(16);
        newUser.PasswordHash = Hasher.Hash(SaltManager.AddSalt(data.password, newUser.Salt));
        newUser.BirthDate = data.birthdate;
        newUser.Picture = data.picture;

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

    [HttpPost("forums")]
    [EnableCors("MainPolicy")]
    public ActionResult Home(
        [FromBody] Jwt token,
        [FromServices] IPostsRepository repo,
        [FromServices] IForumRepository forumrepo,
        [FromServices] IForumUserRepository forumuserrepo,
        [FromServices] IUserRepository userrepo,
        [FromServices] IJwtService jwtService)
    {

        var result = jwtService.Validate<Jwt>(token.value);

        if (result.value == null || result.value == "")
        {
            //TODO - Return not authorized
            return BadRequest();
        }

        List<ForumDisplayData> forums = new();

        foreach (var forum in forumuserrepo.ForumsByUserId(int.Parse(result.value)))
        {
            ForumDisplayData displayData = new();

            displayData.name = forum.Name;
            displayData.id = forum.ForumId;

            forums.Add(displayData);
        } 

        return Ok(forums);

    }
}