using ConfApp.Shared.Models;
using ConfAPI.Data;
using Microsoft.EntityFrameworkCore;

namespace ConfAPI.Services;

public class QuestionService
{
    private readonly ConfDbContext _context;

    public QuestionService(ConfDbContext context)
    {
        _context = context;
    }

    public async Task<List<Question>> GetQuestionsByPresentationIdAsync(int presentationId)
    {
        return await _context.Questions
            .Where(q => q.PresentationId == presentationId)
            .OrderByDescending(q => q.AskedAt)
            .ToListAsync();
    }

    public async Task<Question?> GetQuestionByIdAsync(int id)
    {
        return await _context.Questions.FindAsync(id);
    }

    public async Task<Question> CreateQuestionAsync(Question question)
    {
        question.AskedAt = DateTime.UtcNow;
        _context.Questions.Add(question);
        await _context.SaveChangesAsync();
        return question;
    }

    public async Task<bool> AnswerQuestionAsync(int id, string answer)
    {
        var question = await _context.Questions.FindAsync(id);
        if (question == null)
        {
            return false;
        }

        question.Answer = answer;
        question.IsAnswered = true;
        await _context.SaveChangesAsync();
        return true;
    }

    public async Task<bool> DeleteQuestionAsync(int id)
    {
        var question = await _context.Questions.FindAsync(id);
        if (question == null)
        {
            return false;
        }

        _context.Questions.Remove(question);
        await _context.SaveChangesAsync();
        return true;
    }
}
