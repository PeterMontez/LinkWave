using System.Threading.Tasks;
using LWBack.Data;
using LWBack.Model;

namespace LWBack.Services;

public interface IForumUserRepository
{
    public List<Forum>? ForumsByUserId(int userId);
    public List<User>? UsersByForumId(int forumId);
    public void Create(ForumUser forumUser);
    public void Update(ForumUser forumUser);
    public void Remove(ForumUser forumUser);
}