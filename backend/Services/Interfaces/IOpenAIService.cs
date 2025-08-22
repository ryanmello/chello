namespace backend.Services.Interfaces
{
    public interface IOpenAIService
    {
        Task<string> GetResponseAsync(string userMessage);
        Task<string> GenerateThreadTitle(string message);
    }
}
