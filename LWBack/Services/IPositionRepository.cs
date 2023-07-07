using System.Threading.Tasks;
using LWBack.Data;
using LWBack.Model;

namespace LWBack.Services;

public interface IPositionRepository
{
    public Position? FindByName(string positionName, int forumId);
    public Position? FindById(int positionId);
    public List<Position> FindByForum (int forumId);
    public void Create(Position position);
    public void Remove(Position position);
    public void Update(Position position);
}