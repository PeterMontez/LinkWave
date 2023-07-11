using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using LWBack.Model;
using LWBack.Data;
using LWBack.HashManager;

namespace LWBack.Services;


public class RatingRepository : IRatingRepository
{
    private readonly LinkWaveContext context;
    public RatingRepository(LinkWaveContext context)
        => this.context = context;

    public bool Check(int userid, int postid)
    {
        var query =
            from rating in context.Ratings
            where rating.UserId == userid
            where rating.PostId == postid
            select rating;
        
        var ratingList = query.ToList();
        var result = ratingList.FirstOrDefault();

        return result != null;
    }

    public void Create(Rating rating)
    {
        context.Add(rating);
        context.SaveChanges();
    }

    public Rating FindById(int ratingId)
    {
        var query =
            from rating in context.Ratings
            where rating.RatingId == ratingId
            select rating;
        
        var ratingList = query.ToList();
        var result = ratingList.FirstOrDefault();

        return result;
    }

    // public List<Rating> FindByPost(int postId)
    // {
    //     var query =
    //         from rating in context.Ratings
    //         // where rating.Post == 
    //         select rating;
        
    //     var ratingList = query.ToList();
    //     var result = ratingList.FirstOrDefault();

    //     return result;
    // }

    public void Remove(Rating rating)
    {
        throw new NotImplementedException();
    }

    public void Update(Rating rating)
    {
        throw new NotImplementedException();
    }
}