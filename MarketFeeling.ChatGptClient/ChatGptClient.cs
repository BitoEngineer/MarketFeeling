using OpenAI.ObjectModels.RequestModels;
using OpenAI.ObjectModels;
using OpenAI.Managers;
using OpenAI;

namespace MarketFeeling.ChatGptClient
{
    public class ChatGptClient
    {
        private const string API_KEY = "TODO";

        private readonly HttpClient _httpClient;
        private readonly OpenAIService _openAiService;

        public ChatGptClient(HttpClient httpClient)
        {
            _httpClient = httpClient;
            _openAiService = new OpenAIService(new OpenAiOptions()
            {
                ApiKey = API_KEY
            }, _httpClient);
        }

        public async Task<string> GetAnswerAsync(IEnumerable<string> prompt)
        {
            var messages = prompt.Select(m => ChatMessage.FromUser(m)).ToList();
            var completionResult = await _openAiService.ChatCompletion.CreateCompletion(new ChatCompletionCreateRequest
            {
                Messages = messages,
                Model = Models.ChatGpt3_5Turbo0301
            });
            if (completionResult.Successful)
            {
                return completionResult.Choices.First().Message.Content;
            }
            else
            {
                if (completionResult.Error == null)
                {
                    throw new Exception("Unknown Error");
                }

                throw new Exception(completionResult.Error.Message);
            }
        }
    }
}
