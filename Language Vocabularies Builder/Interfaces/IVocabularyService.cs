using VocabularyBuilder.Models;
namespace VocabularyBuilder.Interfaces;
public interface IVocabularyService
{
    Vocabulary Create(Vocabulary vocabulary);
    Vocabulary Update(int id, Vocabulary vocabulary);
    bool Delete(int id);
    List<Vocabulary> GetAll();
}