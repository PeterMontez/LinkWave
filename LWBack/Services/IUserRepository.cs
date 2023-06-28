using System.Threading.Tasks;
using LWBack.Data;
using LWBack.Model;

namespace LWBack.Services;

public interface IUserRepository
{
    void Create(User user);
    void Update(User user);
    bool Validate(LoginData loginData);
    Task<User> FindByName(string userName);
}