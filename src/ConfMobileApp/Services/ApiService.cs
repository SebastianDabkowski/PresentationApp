using System.Net.Http.Json;
using ConfApp.Shared.Models;

namespace ConfMobileApp.Services;

public class ApiService
{
    private readonly HttpClient _httpClient;
    private const string ApiBaseUrl = "https://localhost:5001/api"; // Update with actual API URL

    public ApiService(HttpClient httpClient)
    {
        _httpClient = httpClient;
        _httpClient.BaseAddress = new Uri(ApiBaseUrl);
    }

    // Presentations
    public async Task<List<Presentation>> GetPresentationsAsync()
    {
        return await _httpClient.GetFromJsonAsync<List<Presentation>>("presentations") ?? new List<Presentation>();
    }

    public async Task<Presentation?> GetPresentationAsync(int id)
    {
        return await _httpClient.GetFromJsonAsync<Presentation>($"presentations/{id}");
    }

    // Questions
    public async Task<List<Question>> GetQuestionsAsync(int presentationId)
    {
        return await _httpClient.GetFromJsonAsync<List<Question>>($"questions/presentation/{presentationId}") ?? new List<Question>();
    }

    public async Task<Question?> CreateQuestionAsync(Question question)
    {
        var response = await _httpClient.PostAsJsonAsync("questions", question);
        response.EnsureSuccessStatusCode();
        return await response.Content.ReadFromJsonAsync<Question>();
    }

    // Ratings
    public async Task<List<Rating>> GetRatingsAsync(int presentationId)
    {
        return await _httpClient.GetFromJsonAsync<List<Rating>>($"ratings/presentation/{presentationId}") ?? new List<Rating>();
    }

    public async Task<double> GetAverageRatingAsync(int presentationId)
    {
        return await _httpClient.GetFromJsonAsync<double>($"ratings/presentation/{presentationId}/average");
    }

    public async Task<Rating?> CreateRatingAsync(Rating rating)
    {
        var response = await _httpClient.PostAsJsonAsync("ratings", rating);
        response.EnsureSuccessStatusCode();
        return await response.Content.ReadFromJsonAsync<Rating>();
    }
}
