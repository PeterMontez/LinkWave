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
[Route("forum")]
[EnableCors("MainPolicy")]
public class ForumController : ControllerBase
{

    [HttpPost("create")]
    public ActionResult Create(
        [FromBody] NewForumData data,
        [FromServices] IForumRepository repo)
    {
        Forum newForum = new Forum();
        newForum.Name = data.Name;
        newForum.Description = data.Description;
        newForum.CreatedAt = DateTime.Now;

        if (repo.CheckNewForum(newForum).Result)
        {
            repo.Create(newForum);
            return Ok();
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



    [HttpGet("home/{forumName}")]
    public IEnumerable<Post>? GetPosts(
    )
    {
        // Where and linq stuff to get the posts
        return null;
    }

}