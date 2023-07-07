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

    public bool IsMemberOf(ForumUser forumUser)
    {

        var query =
            from forumUser2 in context.ForumUsers
            where forumUser2.UserId == forumUser.UserId
            where forumUser2.ForumId == forumUser.ForumId
            select forumUser2;
        
        var forumUser2List = query.ToList();

        if (forumUser2List.FirstOrDefault() == null)
            return false;
        return true;

    }

    public void Remove(ForumUser forumUser)
    {
        context.Remove(forumUser);
        context.SaveChanges();
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