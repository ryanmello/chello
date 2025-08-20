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
    }
}
