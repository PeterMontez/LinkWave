using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using LWBack.Model;
using LWBack.Data;
using LWBack.HashManager;

namespace LWBack.Services;


public class ForumUserRepository : IForumUserRepository
{
    private readonly LinkWaveContext context;
    public ForumUserRepository(LinkWaveContext context)
        => this.context = context;

    public void Create(ForumUser forumUser)
    {
        context.Add(forumUser);
        context.SaveChanges();
    }

    public List<Forum> ForumsByUserId(int userId)
    {
        var query =
            from forumUser in context.ForumUsers
            where forumUser.UserId == userId
            select forumUser;
        
        var forumUserList = query.ToList();

        List<Forum> result = new();

        foreach (var forumUser in forumUserList)
        {
            var forumsquery =
                from forum in context.Forums
                where forum.ForumId == forumUser.ForumId
                select forum;

            var singleForum = forumsquery.ToList();

            result.Add(singleForum.FirstOrDefault());
        }

        return result;
    }

    public void Remove(ForumUser forumUser)
    {
        throw new NotImplementedException();
    }

    public void Update(ForumUser forumUser)
    {
        throw new NotImplementedException();
    }

    public List<User> UsersByForumId(int forumId)
    {
        throw new NotImplementedException();
    }
}