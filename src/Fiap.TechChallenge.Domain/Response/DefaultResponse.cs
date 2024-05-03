using System.Text.Json.Serialization;

namespace Fiap.TechChallenge.Domain.Response;


public class DefaultResponse<T>
{
    public DefaultResponse()
    {
    }

    public string Message { get; set; }
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public T? Data { get; set; }
}
