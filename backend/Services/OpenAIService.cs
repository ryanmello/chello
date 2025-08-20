using OpenAI;
using OpenAI.Chat;

namespace backend.Services
{
    public class OpenAIService
    {

        public OpenAIService()
        {

        }

        public async Task<string> GetResponseAsync(string userMessage)
        {
            var client = new ChatClient("gpt-4o", "");
            var response = await client.CompleteChatAsync("What is the capital of France?");
            return response.Value.Content[0].Text;
        }
    }
}
