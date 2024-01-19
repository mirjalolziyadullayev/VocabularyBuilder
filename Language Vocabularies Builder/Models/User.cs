using System.Text.Json.Serialization;
namespace Language_Vocabularies_Builder.Models;
public class User
{
    private static int id=0;
        public User()
    {
        Id = +id;
    }
    [JsonPropertyName("id")]
    public int Id { get; set; }

    [JsonPropertyName("name")]
    public string Name { get; set; }

    [JsonPropertyName("sVocabularies")]
    public List<Vocabulary> SavedVocabularies { get; set; }
}