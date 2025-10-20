namespace ConfApp.Shared.Models;

public class Rating
{
    public int Id { get; set; }
    public int PresentationId { get; set; }
    public string RatedBy { get; set; } = string.Empty;
    public int Score { get; set; } // 1-5
    public string? Comment { get; set; }
    public DateTime RatedAt { get; set; }
}
