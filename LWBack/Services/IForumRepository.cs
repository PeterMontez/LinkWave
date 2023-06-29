using System.Threading.Tasks;
using LWBack.Data;
using LWBack.Model;

namespace LWBack.Services;

public interface IForumRepository
{
    public Forum? FindByName(string forumName);
    public NewForumCheckData CheckNewForum(Forum forum);
    public void Create(Forum forum);
    public void Remove(Forum forum);
    public void Update(Forum forum);
}