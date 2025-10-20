using ConfApp.Shared.Models;
using ConfAPI.Services;
using Microsoft.AspNetCore.Mvc;

namespace ConfAPI.Controllers;

[ApiController]
[Route("api/[controller]")]
public class RatingsController : ControllerBase
{
    private readonly RatingService _ratingService;

    public RatingsController(RatingService ratingService)
    {
        _ratingService = ratingService;
    }

    [HttpGet("presentation/{presentationId}")]
    public async Task<ActionResult<List<Rating>>> GetRatingsByPresentation(int presentationId)
    {
        var ratings = await _ratingService.GetRatingsByPresentationIdAsync(presentationId);
        return Ok(ratings);
    }

    [HttpGet("presentation/{presentationId}/average")]
    public async Task<ActionResult<double>> GetAverageRating(int presentationId)
    {
        var average = await _ratingService.GetAverageRatingAsync(presentationId);
        return Ok(average);
    }

    [HttpPost]
    public async Task<ActionResult<Rating>> CreateRating(Rating rating)
    {
        var created = await _ratingService.CreateRatingAsync(rating);
        return Ok(created);
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> DeleteRating(int id)
    {
        var deleted = await _ratingService.DeleteRatingAsync(id);
        if (!deleted)
        {
            return NotFound();
        }

        return NoContent();
    }
}
