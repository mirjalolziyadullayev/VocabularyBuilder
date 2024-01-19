using VocabularyBuilder.Interfaces;
using VocabularyBuilder.Models;
using Newtonsoft.Json;
using System.Text;
using Microsoft.VisualBasic;

namespace VocabularyBuilder.Services;
public class VocabularyService : IVocabularyService
{
    private readonly List<Vocabulary> vocabularies;
    public VocabularyService()
    {
        vocabularies = new List<Vocabulary>();
    }
    public Vocabulary Create(Vocabulary vocabulary)
    {
        vocabularies.Add(vocabulary);

        var content = JsonConvert.SerializeObject(vocabularies, Formatting.Indented);
        File.WriteAllText(Path.PathVocabs, content);
        return vocabulary;
    }
    public List<Vocabulary> GetAll()
    {
        var content = File.ReadAllText(Path.PathVocabs);
        return JsonConvert.DeserializeObject<List<Vocabulary>>(content);
    }
    public Vocabulary Update(int id, Vocabulary vocabulary)
    {
        var content = File.ReadAllText(Path.PathVocabs);
        List<Vocabulary> Vocabularies = JsonConvert.DeserializeObject<List<Vocabulary>>(content);

        foreach (var item in vocabularies)
        {
            if (item.Id == id)
            {
                item.OriginalLanguage = vocabulary.OriginalLanguage;
                item.TranslateLanguage = vocabulary.TranslateLanguage;
                item.Word = vocabulary.Word;
                item.Definition = vocabulary.Definition;
                item.Synonyms = vocabulary.Synonyms;
                item.Example = vocabulary.Example;

                break;
            }
        }
        var result = JsonConvert.SerializeObject(vocabularies, Formatting.Indented);
        File.WriteAllText(Path.PathVocabs, result);

        return vocabulary;
    }
    public bool Delete(int id)
    {
        var content = File.ReadAllText(Path.PathVocabs);
        List<Vocabulary> Vocabularies = JsonConvert.DeserializeObject<List<Vocabulary>>(content);

        foreach (var item in vocabularies)
        {
            if (item.Id == id)
            {
                vocabularies.Remove(item);
                break;
            }
        }
        var result = JsonConvert.SerializeObject(vocabularies, Formatting.Indented);
        File.WriteAllText(Path.PathVocabs, result);

        return true;
    }
    public Vocabulary GetById(int vocabularyId)
    {
        var vocabulary = GetAll().FirstOrDefault(vocabulary => vocabulary.Id == vocabularyId)
        ?? throw new Exception("User is not found");//?? bu null bo'sa degani
        return vocabulary;
    }
}

