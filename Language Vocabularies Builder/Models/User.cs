using System.Text.Json.Serialization;
namespace VocabularyBuilder.Models;
public class User
{
    
    [JsonPropertyName("id")]
    public int Id { get; set; }

    [JsonPropertyName("name")]
    public string Name { get; set; }

    [JsonPropertyName("savedVocabs")]
    public List<Vocabulary> SavedVocabularies { get; set; }
}