using System.Threading.Tasks;

namespace LWBack.Model;

public interface IUserRepository
{
    void Create(User user);
    void Update(User user);
    Task<User> FindByName(string userName);
}