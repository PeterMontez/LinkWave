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

    [HttpPost("create")]
    public ActionResult Create(
        [FromBody] PostData data,
        [FromServices] IPostsRepository repo)
    {
        Post newPost = new Post();
        newPost.Title = data.title;
        newPost.Content = data.content;
        newPost.Picture = "";
        newPost.UserId = data.userid;
        newPost.ForumId = data.forumid;

        repo.Create(newPost);

        return Ok(true);

    }

    [HttpPost("forum/{id}")]
    [EnableCors("MainPolicy")]
    public ActionResult Signin(
        [FromBody] Jwt token,
        [FromServices] IPostsRepository repo,
        [FromServices] IForumRepository forumrepo,
        [FromServices] IUserRepository userrepo,
        [FromServices] IJwtService jwtService, string id)
    {

        var result = jwtService.Validate<Jwt>(token.value);

        var fullposts = repo.FindByForum(int.Parse(id));

        List<PostDisplayData> posts = new List<PostDisplayData>();

        foreach (var post in fullposts)
        {
            PostDisplayData tempPost = new();

            tempPost.user = userrepo.FindById((int)post.UserId).Username;
            tempPost.title = post.Title;
            tempPost.content = post.Content;
            tempPost.picture = post.Picture;
            tempPost.likes = 0;
            tempPost.dislikes = 0;
            tempPost.forum = forumrepo.FindById((int)post.ForumId).Name;

            posts.Add(tempPost);

        }

        posts.Reverse();

        return Ok(posts);

    }

    [HttpPost("home")]
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

        List<PostDisplayData> AllPosts = new();

        foreach (var forum in forumuserrepo.ForumsByUserId(int.Parse(result.value)))
        {
            var fullposts = repo.FindByForum(forum.ForumId);

            List<PostDisplayData> tempPosts = new List<PostDisplayData>();

            foreach (var post in fullposts)
            {
                PostDisplayData tempPost = new();

                tempPost.user = userrepo.FindById((int)post.UserId).Username;
                tempPost.title = post.Title;
                tempPost.content = post.Content;
                tempPost.picture = post.Picture;
                tempPost.likes = 0;
                tempPost.dislikes = 0;
                tempPost.forum = forumrepo.FindById((int)post.ForumId).Name;

                tempPosts.Add(tempPost);

            }

            AllPosts.AddRange(tempPosts);

        }

        Random _rand = new();

        for (int i = AllPosts.Count - 1; i > 0; i--)
        {
            var k = _rand.Next(i + 1);
            var value = AllPosts[k];
            AllPosts[k] = AllPosts[i];
            AllPosts[i] = value;
        }

        AllPosts.Reverse();

        return Ok(AllPosts);

    }

}