namespace ConfApp.Shared.Models;

public class Question
{
    public int Id { get; set; }
    public int PresentationId { get; set; }
    public string AskedBy { get; set; } = string.Empty;
    public string Text { get; set; } = string.Empty;
    public DateTime AskedAt { get; set; }
    public bool IsAnswered { get; set; }
    public string? Answer { get; set; }
}
