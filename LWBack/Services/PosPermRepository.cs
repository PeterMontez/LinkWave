using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using LWBack.Model;
using LWBack.Data;
using LWBack.HashManager;

namespace LWBack.Services;


public class PosPermRepository : IPosPermRepository
{
    private readonly LinkWaveContext context;
    public PosPermRepository(LinkWaveContext context)
        => this.context = context;

    public void Create(PosPerm posperm)
    {
        context.Add(posperm);
        context.SaveChanges();
    }

    public PosPerm FindById(int pospermId)
    {
        var query =
            from posperm in context.PosPerms
            where posperm.PosPermId == pospermId
            select posperm;
        
        var pospermList = query.ToList();
        var result = pospermList.FirstOrDefault();

        return result;
    }

    public List<PosPerm> FindByPosition(int positionId)
    {
        var query =
            from posperm in context.PosPerms
            where posperm.PositionId == positionId
            select posperm;
        
        var pospermList = query.ToList();
        var result = pospermList.FirstOrDefault();

        return pospermList;
    }

    public void Remove(PosPerm posperm)
    {
        throw new NotImplementedException();
    }

    public void Update(PosPerm posperm)
    {
        throw new NotImplementedException();
    }
}