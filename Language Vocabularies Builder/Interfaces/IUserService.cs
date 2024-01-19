using VocabularyBuilder.Models;
namespace VocabularyBuilder.Interfaces;
public interface IUserService
{
    User Create(User user);
    User Update(int id, User user);
    bool Delete(int id);
    User GetById(int id);
    List<User> GetAll();
    (bool, bool) AddVocabulary(int userID, int vocabID);
}