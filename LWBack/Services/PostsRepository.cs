using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using LWBack.Model;
using LWBack.Data;
using LWBack.HashManager;

namespace LWBack.Services;


public class PostsRepository : IPostsRepository
{
    private readonly LinkWaveContext context;
    public PostsRepository(LinkWaveContext context)
        => this.context = context;

    public void Create(Post post)
    {
        context.Add(post);
        context.SaveChanges();
    }

    public List<Post>? FindByForum(int forumId)
    {
        var query =
            from post in context.Posts
            where post.ForumId == forumId
            select post;
        
        var postList = query.ToList();

        return postList;
    }

    public Post? FindById(int postId)
    {
        var query =
            from post in context.Posts
            where post.PostId == postId
            select post;
        
        var postList = query.ToList();
        var result = postList.FirstOrDefault();

        return result;
    }

    public List<Post>? FindByUser(int userId)
    {
        var query =
            from post in context.Posts
            where post.UserId == userId
            select post;
        
        var postList = query.ToList();
        var result = postList.FirstOrDefault();

        return postList;
    }

    public void Remove(Post post)
    {
        throw new NotImplementedException();
    }
}