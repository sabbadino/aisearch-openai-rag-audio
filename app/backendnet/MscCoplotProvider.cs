using System.Security.Cryptography;
using System.Text;
using System.Text.Json;

namespace backendnet
{
    public interface IMscCopilotProvider
    {
        Task<string> GetReply(AnswerTouUserRequest userQuery);
    }
    public class MscCopilotProvider : IMscCopilotProvider
    {
        private readonly IHttpClientFactory _httpClientFactory;
        public MscCopilotProvider(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }
        private static readonly JsonSerializerOptions Opt = new JsonSerializerOptions
        {
            PropertyNameCaseInsensitive = true,
        };
        public async Task<string> GetReply(AnswerTouUserRequest userQuery)
        {
            var byt = Encoding.UTF8.GetBytes(userQuery.SessionId);
            var conversationId = new Guid(MD5.Create().ComputeHash(byt));
            var client = _httpClientFactory.CreateClient();
            var url = "https://localhost:7174/chat/ask";
            HttpRequestMessage ms = new HttpRequestMessage(HttpMethod.Post, url);
            ms.Content = new StringContent(JsonSerializer.Serialize(new MscCopilotTypes.UserQuestionDto
            {
                ConversationId = conversationId,
                Question = userQuery.user_prompt
            }), Encoding.UTF8, "application/json");
            ms.Headers.Add("User-Email","enrico.sabbadin@msc.com");
            var ret = await client.SendAsync(ms);
            if (ret.IsSuccessStatusCode)
            {
                Console.WriteLine("OK");
            }
            else
            {
                throw new Exception($"error calling url {url} status code {ret.StatusCode} body {await ret.Content.ReadAsStringAsync()}");
            }
            if (!ret.IsSuccessStatusCode)
            {
                throw new Exception($"{ret.StatusCode} + {await ret.Content.ReadAsStringAsync()}");
            }
            var response = await ret.Content.ReadAsStringAsync();
            var answerToUserDto = JsonSerializer.Deserialize<MscCopilotTypes.AnswerToUserDto>(response, Opt);
            return answerToUserDto.Answer;  

        }
    }

 
   
 


}
