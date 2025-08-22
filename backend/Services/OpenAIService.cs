using backend.Config;
using backend.Services.Interfaces;
using Microsoft.Extensions.Options;
using OpenAI;
using OpenAI.Chat;

namespace backend.Services
{
    public class OpenAIService : IOpenAIService
    {
        private readonly OpenAIOptions _options;
        private readonly ChatClient _client;

        public OpenAIService(IOptions<OpenAIOptions> options) 
        { 
            _options = options.Value;
            _client = new ChatClient(_options.Model, _options.ApiKey);
        }

        public async Task<string> GetResponseAsync(string userMessage)
        {
            var response = await _client.CompleteChatAsync(userMessage);
            return response.Value.Content[0].Text;
        }

        public async Task<string> GenerateThreadTitle(string message)
        {
            var response = await _client.CompleteChatAsync("Generate a thread title based on the following message. Ouput should be at most 30 charcaters (inclduing spaces). Never include quotes in the title. Message: " + message);
            
            var title = response.Value.Content[0].Text;
            if (title[0] == '"' && title[title.Length - 1] == '"')
            {
                title = title.Substring(1, title.Length - 2);
            }

            return title;
        }
    }
}
