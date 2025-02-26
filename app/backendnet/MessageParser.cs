using Newtonsoft.Json.Linq;
using System.Text;
using System.Text.Json;
using System.Text.Json.Nodes;

namespace backendnet;

public interface IMessageParser
{
    JObject? GetJson(byte[] payload, int count);
    string? GetCommandName(byte[] payload);
}

public class MessageParser : IMessageParser
{
    private static readonly Encoding Utf8Encoding = Encoding.UTF8;

    public JObject? GetJson(byte[] payload, int count)
    {
        try
        {
            var input = Utf8Encoding.GetString(payload, 0, count);
            //   Console.WriteLine($"{context}: {input}");
            try
            {
                var jObject = JObject.Parse(input);
                if (jObject != null)
                {
                    return jObject;
                }
                Console.WriteLine($"jObject is null from {input}");
                throw new Exception($"jObject is null from {input}");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"failed to parse data {input} as json error is {ex}");
                //throw;
                return null;
            }

        }
        catch (Exception ex)
        {
            throw;
        }
    }
    public string? GetCommandName(byte[] payload)
    {
        var reader = new Utf8JsonReader(payload);
        while (reader.Read())
        {
            JsonTokenType tokenType = reader.TokenType;
            switch (tokenType)
            {
                case JsonTokenType.PropertyName:
                    if (reader.ValueTextEquals("type"))
                    {
                        reader.Read();
                        if (reader.TokenType == JsonTokenType.String)
                        {
                            return reader.GetString() ?? null;
                        }
                    }
                    break;
            }
        }
        return null;
    }


}