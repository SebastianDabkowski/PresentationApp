namespace ConfApp.Shared.Models;

public class Presentation
{
    public int Id { get; set; }
    public string Title { get; set; } = string.Empty;
    public string Speaker { get; set; } = string.Empty;
    public string Description { get; set; } = string.Empty;
    public DateTime StartTime { get; set; }
    public DateTime EndTime { get; set; }
    public string Room { get; set; } = string.Empty;
    public List<Question> Questions { get; set; } = new();
    public List<Rating> Ratings { get; set; } = new();
}
