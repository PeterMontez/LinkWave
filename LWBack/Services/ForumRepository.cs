using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using LWBack.Model;
using LWBack.Data;
using LWBack.HashManager;

namespace LWBack.Services;


public class ForumRepository : IForumRepository
{
    private readonly LinkWaveContext context;
    public ForumRepository(LinkWaveContext context)
        => this.context = context;

    public NewForumCheckData CheckNewForum(Forum forum)
    {
        NewForumCheckData check = new NewForumCheckData();
        if (FindByName(forum.Name) != null)
        {
            check.ReturnMsg = "A forum with this name already exists.";
            check.Result = false;
            return check;
        }

        check.Result = true;
        return check;
    }

    public void Create(Forum forum)
    {
        context.Add(forum);
        context.SaveChanges();
    }

    public Forum? FindByName(string forumName)
    {
        var query =
            from forum in context.Forums
            where forum.Name == forumName
            select forum;
        
        var forumList = query.ToList();
        var result = forumList.FirstOrDefault();

        return result;
    }

    public Forum? FindById(int forumId)
    {
        var query =
            from forum in context.Forums
            where forum.ForumId == forumId
            select forum;
        
        var forumList = query.ToList();
        var result = forumList.FirstOrDefault();

        return result;
    }

    public void Remove(Forum forum)
    {
        context.Remove(forum);
        context.SaveChanges();
    }

    public void Update(Forum forum)
    {
        context.Update(forum);
        context.SaveChanges();
    }
}