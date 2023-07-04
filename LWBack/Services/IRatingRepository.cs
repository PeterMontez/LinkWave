using System.Threading.Tasks;
using LWBack.Data;
using LWBack.Model;

namespace LWBack.Services;

public interface IRatingRepository
{
    public Rating? FindById(int ratingId);
    public List<Rating> FindByPost(int postId);
    public void Create(Rating rating);
    public void Remove(Rating rating);
    public void Update(Rating rating);
}