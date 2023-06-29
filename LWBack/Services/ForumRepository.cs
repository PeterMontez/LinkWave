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

    public void Create(Forum forum)
    {
        context.Add(forum);
        context.SaveChanges();
    }

    public Forum? FindByName(string forumName)
    {
        throw new NotImplementedException();
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