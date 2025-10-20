using ConfApp.Shared.Models;
using ConfAPI.Services;
using Microsoft.AspNetCore.Mvc;

namespace ConfAPI.Controllers;

[ApiController]
[Route("api/[controller]")]
public class PresentationsController : ControllerBase
{
    private readonly PresentationService _presentationService;

    public PresentationsController(PresentationService presentationService)
    {
        _presentationService = presentationService;
    }

    [HttpGet]
    public async Task<ActionResult<List<Presentation>>> GetPresentations()
    {
        var presentations = await _presentationService.GetAllPresentationsAsync();
        return Ok(presentations);
    }

    [HttpGet("{id}")]
    public async Task<ActionResult<Presentation>> GetPresentation(int id)
    {
        var presentation = await _presentationService.GetPresentationByIdAsync(id);
        if (presentation == null)
        {
            return NotFound();
        }
        return Ok(presentation);
    }

    [HttpPost]
    public async Task<ActionResult<Presentation>> CreatePresentation(Presentation presentation)
    {
        var created = await _presentationService.CreatePresentationAsync(presentation);
        return CreatedAtAction(nameof(GetPresentation), new { id = created.Id }, created);
    }

    [HttpPut("{id}")]
    public async Task<IActionResult> UpdatePresentation(int id, Presentation presentation)
    {
        if (id != presentation.Id)
        {
            return BadRequest();
        }

        var updated = await _presentationService.UpdatePresentationAsync(presentation);
        if (!updated)
        {
            return NotFound();
        }

        return NoContent();
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> DeletePresentation(int id)
    {
        var deleted = await _presentationService.DeletePresentationAsync(id);
        if (!deleted)
        {
            return NotFound();
        }

        return NoContent();
    }
}
