using System.Text.Json.Serialization;
namespace VocabularyBuilder.Models;
public class Vocabulary
{
    [JsonPropertyName("id")]
    public int Id { get; set; }
    [JsonPropertyName("userId")]
    public int UserId { get; set; }

    [JsonPropertyName("original")]
    public string Language { get; set; }

    [JsonPropertyName("translated")]
    public string TranslateLanguage { get; set; }

    [JsonPropertyName("word")]
    public string Word { get; set; }
}
