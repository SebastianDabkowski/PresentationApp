using ConfApp.Shared.Models;
using ConfAPI.Services;
using Microsoft.AspNetCore.Mvc;

namespace ConfAPI.Controllers;

[ApiController]
[Route("api/[controller]")]
public class QuestionsController : ControllerBase
{
    private readonly QuestionService _questionService;

    public QuestionsController(QuestionService questionService)
    {
        _questionService = questionService;
    }

    [HttpGet("presentation/{presentationId}")]
    public async Task<ActionResult<List<Question>>> GetQuestionsByPresentation(int presentationId)
    {
        var questions = await _questionService.GetQuestionsByPresentationIdAsync(presentationId);
        return Ok(questions);
    }

    [HttpGet("{id}")]
    public async Task<ActionResult<Question>> GetQuestion(int id)
    {
        var question = await _questionService.GetQuestionByIdAsync(id);
        if (question == null)
        {
            return NotFound();
        }
        return Ok(question);
    }

    [HttpPost]
    public async Task<ActionResult<Question>> CreateQuestion(Question question)
    {
        var created = await _questionService.CreateQuestionAsync(question);
        return CreatedAtAction(nameof(GetQuestion), new { id = created.Id }, created);
    }

    [HttpPut("{id}/answer")]
    public async Task<IActionResult> AnswerQuestion(int id, [FromBody] string answer)
    {
        var updated = await _questionService.AnswerQuestionAsync(id, answer);
        if (!updated)
        {
            return NotFound();
        }

        return NoContent();
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> DeleteQuestion(int id)
    {
        var deleted = await _questionService.DeleteQuestionAsync(id);
        if (!deleted)
        {
            return NotFound();
        }

        return NoContent();
    }
}
