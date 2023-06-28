using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using LWBack.Model;
using LWBack.Data;

namespace LWBack.Services;


public class UserRepository : IUserRepository
{
    private readonly LinkWaveContext context;
    public UserRepository(LinkWaveContext context)
        => this.context = context;

    public async Task<User> FindByName(string userName)
    {
        var query =
            from user in context.Users
            where user.Username == userName
            select user;
        
        var userList = await query.ToListAsync();
        var logged = userList.FirstOrDefault();
        
        return logged;
    }

    void IUserRepository.Create(User user)
    {
        context.Add(user);
        context.SaveChanges();
    }

    void IUserRepository.Update(User user)
    {
        context.Update(user);
        context.SaveChanges();
    }

    bool IUserRepository.Validate(LoginData loginData)
    {
        
    }
}