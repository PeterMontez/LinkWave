using System.Threading.Tasks;
using LWBack.Data;
using LWBack.Model;

namespace LWBack.Services;

public interface IUserRepository
{
    public User? FindByName(string userName);
    public User? FindByEmail(string email);
    public void Create(User user);
    public void Update(User user);
    public bool Validate(LoginData loginData);
    public SignInCheckData CheckNewUser(User user);
}