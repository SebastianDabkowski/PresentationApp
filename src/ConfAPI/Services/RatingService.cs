using ConfApp.Shared.Models;
using ConfAPI.Data;
using Microsoft.EntityFrameworkCore;

namespace ConfAPI.Services;

public class RatingService
{
    private readonly ConfDbContext _context;

    public RatingService(ConfDbContext context)
    {
        _context = context;
    }

    public async Task<List<Rating>> GetRatingsByPresentationIdAsync(int presentationId)
    {
        return await _context.Ratings
            .Where(r => r.PresentationId == presentationId)
            .OrderByDescending(r => r.RatedAt)
            .ToListAsync();
    }

    public async Task<double> GetAverageRatingAsync(int presentationId)
    {
        var ratings = await _context.Ratings
            .Where(r => r.PresentationId == presentationId)
            .Select(r => r.Score)
            .ToListAsync();

        return ratings.Any() ? ratings.Average() : 0;
    }

    public async Task<Rating> CreateRatingAsync(Rating rating)
    {
        rating.RatedAt = DateTime.UtcNow;
        _context.Ratings.Add(rating);
        await _context.SaveChangesAsync();
        return rating;
    }

    public async Task<bool> DeleteRatingAsync(int id)
    {
        var rating = await _context.Ratings.FindAsync(id);
        if (rating == null)
        {
            return false;
        }

        _context.Ratings.Remove(rating);
        await _context.SaveChangesAsync();
        return true;
    }
}
