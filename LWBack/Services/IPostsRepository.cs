using System.Threading.Tasks;
using LWBack.Data;
using LWBack.Model;

namespace LWBack.Services;

public interface IPostsRepository
{
    public Post FindById(int postId);
    public List<Post>? FindByUser(int userId);
    public List<Post>? FindByForum(int forumId);
    public void Create(Post post);
    public void Remove(Post post);
    
}