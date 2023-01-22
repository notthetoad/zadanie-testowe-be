using System.Text.Json.Serialization;

namespace TestApi.Models;

public class RandomUserSet
{
    [JsonPropertyName("results")]
    public List<User>? Results { get; set; }

    public class User
    {
        [JsonPropertyName("name")]
        public Name? Name { get; set; }
        [JsonPropertyName("email")]
        public string? Email { get; set; }
    }

    public class Name
    {
        [JsonPropertyName("first")]
        public string? FirstName { get; set; }
        [JsonPropertyName("last")]
        public string? LastName { get; set; }
    }
}
