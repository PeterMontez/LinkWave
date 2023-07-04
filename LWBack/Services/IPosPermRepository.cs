using System.Threading.Tasks;
using LWBack.Data;
using LWBack.Model;

namespace LWBack.Services;

public interface IPosPermRepository
{
    public List<PosPerm> FindByPosition(int positionId);
    public PosPerm? FindById(int pospermId);
    public void Create(PosPerm posperm);
    public void Remove(PosPerm posperm);
    public void Update(PosPerm posperm);
}