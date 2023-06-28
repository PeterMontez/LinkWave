using System.Threading.Tasks;

namespace LWBack.Model;

public interface IUserRepository
{
    Task Create(User user);
    Task Update(User user);
    Task<User> FindByName(string userName);
}