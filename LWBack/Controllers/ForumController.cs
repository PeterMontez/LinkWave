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
using Security_jwt;

namespace LWBack.Controllers;

[ApiController]
[Route("forum")]
[EnableCors("MainPolicy")]
public class ForumController : ControllerBase
{

    [HttpPost("create")]
    public ActionResult Create(
        [FromBody] NewForumData data,
        [FromServices] IForumRepository repo,
        [FromServices] IForumUserRepository forumuserrepo,
        [FromServices] IJwtService jwtService,
        [FromServices] IPositionRepository positionrepo)
    {
        var result = jwtService.Validate<Jwt>(data.Token);

        Forum newForum = new Forum();
        newForum.Name = data.Name;
        newForum.Description = data.Description;
        newForum.CreatedAt = DateTime.Now;

        if (repo.CheckNewForum(newForum).Result)
        {
            repo.Create(newForum);

            Position position = new();

            position.Name = "Owner";
            position.ForumId = repo.FindByName(newForum.Name).ForumId;
            positionrepo.Create(position);

            Position newposition = new();

            newposition.Name = "User";
            newposition.ForumId = repo.FindByName(newForum.Name).ForumId;
            positionrepo.Create(newposition);

            ForumUser forumUser = new();

            forumUser.UserId = int.Parse(result.value);
            forumUser.ForumId = repo.FindByName(newForum.Name).ForumId;
            forumUser.PositionId = positionrepo.FindByName("Owner", repo.FindByName(newForum.Name).ForumId).PositionId;

            forumuserrepo.Create(forumUser);

            return Ok(true);
        }

        else
        {
            return BadRequest(repo.CheckNewForum(newForum).ReturnMsg);
        }

    }

    [HttpPost("addposition")]
    public ActionResult addposition(
        [FromBody] NewPositionData data,
        [FromServices] IPositionRepository repo)
    {
        Position position = new();

        position.Name = data.name;
        position.ForumId = data.forumId;

        repo.Create(position);

        return Ok();
    }

    [HttpPost("addpermissions")]
    public ActionResult addpermissions(
        [FromBody] NewPermissionData data,
        [FromServices] IPosPermRepository repo)
    {
        foreach (var permission in data.permissions)
        {
            PosPerm posPerm = new();

            posPerm.PermissionId = permission;
            posPerm.PositionId = data.position;

            repo.Create(posPerm);
        }

        return Ok();
    }

    [HttpPost("info/{id}")]
    public ActionResult GetInfo(
        [FromBody] Jwt token,
        [FromServices] IForumRepository repo,
        [FromServices] IForumUserRepository forumuserrepo,
        [FromServices] IPositionRepository positionrepo,
        [FromServices] IJwtService jwtService, string id)
    {
        var result = jwtService.Validate<Jwt>(token.value);

        // name: string
        // createdat: string
        // description: string
        // position: string
        // followers: number

        ForumCardData forumCardData = new();

        Forum crrforum = repo.FindById(int.Parse(id));

        forumCardData.name = crrforum.Name;
        forumCardData.createdat = crrforum.CreatedAt.ToString("dd/MM/yyyy");
        forumCardData.description = crrforum.Description;

        ForumUser forumUser = forumuserrepo.GetForumUser(int.Parse(result.value), int.Parse(id));

        forumCardData.position = positionrepo.FindById((int)forumUser.PositionId).Name;
        forumCardData.followers = forumuserrepo.UsersByForumId(crrforum.ForumId).Count();

        return Ok(forumCardData);
    }

    [HttpPost("search/{input}")]
    public ActionResult Search(
        [FromBody] Jwt token,
        [FromServices] IJwtService jwtService,
        [FromServices] IForumUserRepository forumuserrepo,
        [FromServices] IForumRepository repo,
        string input)
    {
        var result = jwtService.Validate<Jwt>(token.value);

        List<Forum> forums = repo.Search(input);

        List<ForumSearchData> searchData = new();
        
        foreach (var forum in forums)
        {
            ForumSearchData tempData = new();

            tempData.name = forum.Name;
            tempData.id = forum.ForumId;
            tempData.followers = forumuserrepo.UsersByForumId(forum.ForumId).Count().ToString();
            tempData.description = forum.Description;

            searchData.Add(tempData);
        }

        return Ok(searchData);
    }

}