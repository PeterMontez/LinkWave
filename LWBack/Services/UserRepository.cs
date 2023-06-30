using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using LWBack.Model;
using LWBack.Data;
using LWBack.HashManager;

namespace LWBack.Services;


public class UserRepository : IUserRepository
{
    private readonly LinkWaveContext context;
    public UserRepository(LinkWaveContext context)
        => this.context = context;

    public User? FindByName(string userName)
    {
        var query =
            from user in context.Users
            where user.Username == userName
            select user;
        
        var userList = query.ToList();
        var logged = userList.FirstOrDefault();

        return logged;
    }

    public User? FindByEmail(string email)
    {
        var query =
            from user in context.Users
            where user.Email == email
            select user;
        
        var userList = query.ToList();
        var logged = userList.FirstOrDefault();

        return logged;
    }

    public SignInCheckData CheckNewUser(User user)
    {
        SignInCheckData result = new SignInCheckData();
        
        if (FindByEmail(user.Email) != null)
        {
            result.ReturnMsg = "Email already in use.";
            result.Result = false;
            return result;
        }

        if (FindByName(user.Username) != null)
        {
            result.ReturnMsg = "Username already in use.";
            result.Result = false;
            return result;
        }

        result.Result = true;
        return result;
        
    }

    public void Create(User user)
    {
        context.Add(user);
        context.SaveChanges();
    }

    public void Update(User user)
    {
        context.Update(user);
        context.SaveChanges();
    }

    public bool Validate(LoginData loginData)
    {
        User? user = FindByName(loginData.user);

        if (user == null && loginData.user.Contains('@'))
        {
            FindByEmail(loginData.user);
        }
        
        if (user != null)
        {
            if (Hasher.Hash(SaltManager.AddSalt(loginData.password, user.Salt)) == user.PasswordHash)
            {
                return true;
            }
        }

        return false;

    }

}