using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using LWBack.Model;
using LWBack.Data;
using LWBack.HashManager;

namespace LWBack.Services;


public class PositionRepository : IPositionRepository
{
    private readonly LinkWaveContext context;
    public PositionRepository(LinkWaveContext context)
        => this.context = context;

    public void Create(Position position)
    {
        context.Add(position);
        context.SaveChanges();
    }

    public Position? FindById(int positionId)
    {
        var query =
            from position in context.Positions
            where position.PositionId == positionId
            select position;
        
        var positionList = query.ToList();
        var result = positionList.FirstOrDefault();

        return result;
    }

    public Position? FindByName(string positionName, int forumId)
    {
        var query =
            from position in context.Positions
            where position.Name == positionName
            where position.ForumId == forumId
            select position;

        var positionList = query.ToList();
        var result = positionList.FirstOrDefault();

        return result;
    }

    public void Remove(Position position)
    {
        context.Remove(position);
        context.SaveChanges();
    }

    public void Update(Position position)
    {
        context.Update(position);
        context.SaveChanges();
    }
}