using ConfApp.Shared.Models;
using ConfAPI.Data;
using Microsoft.EntityFrameworkCore;

namespace ConfAPI.Services;

public class PresentationService
{
    private readonly ConfDbContext _context;

    public PresentationService(ConfDbContext context)
    {
        _context = context;
    }

    public async Task<List<Presentation>> GetAllPresentationsAsync()
    {
        return await _context.Presentations
            .Include(p => p.Questions)
            .Include(p => p.Ratings)
            .ToListAsync();
    }

    public async Task<Presentation?> GetPresentationByIdAsync(int id)
    {
        return await _context.Presentations
            .Include(p => p.Questions)
            .Include(p => p.Ratings)
            .FirstOrDefaultAsync(p => p.Id == id);
    }

    public async Task<Presentation> CreatePresentationAsync(Presentation presentation)
    {
        _context.Presentations.Add(presentation);
        await _context.SaveChangesAsync();
        return presentation;
    }

    public async Task<bool> UpdatePresentationAsync(Presentation presentation)
    {
        _context.Entry(presentation).State = EntityState.Modified;
        try
        {
            await _context.SaveChangesAsync();
            return true;
        }
        catch (DbUpdateConcurrencyException)
        {
            return false;
        }
    }

    public async Task<bool> DeletePresentationAsync(int id)
    {
        var presentation = await _context.Presentations.FindAsync(id);
        if (presentation == null)
        {
            return false;
        }

        _context.Presentations.Remove(presentation);
        await _context.SaveChangesAsync();
        return true;
    }
}
