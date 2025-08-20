namespace backend.Services.Interfaces
{
    public interface IOpenAIService
    {
        Task<string> GetResponseAsync(string userMessage);
    }
}
