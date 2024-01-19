using Newtonsoft.Json;
using VocabularyBuilder.Interfaces;
using VocabularyBuilder.Models;
namespace VocabularyBuilder.Services;
public class UserService : IUserService
{
    private readonly List<User> users;
    public UserService()
    {
        users = new List<User>();
    }

    public (bool, bool) AddVocabulary(int userID, int vocabID)
    {
        var userFound = false;
        var vocabFound = false;

        var uContent = File.ReadAllText(Path.PathUser);
        List<User> Users = JsonConvert.DeserializeObject<List<User>>(uContent);

        var vContent = File.ReadAllText(Path.PathVocabs);
        List<Vocabulary> Vocabs = JsonConvert.DeserializeObject<List<Vocabulary>>(vContent);

        var vocab = Vocabs.FirstOrDefault(Vocabulary => Vocabulary.Id == vocabID);
        if (vocab != null)
        {
            vocabFound = true;
            foreach (var User in Users)
            {
                if (User.Id == userID)
                {
                    List<Vocabulary> vocabularies = new List<Vocabulary>();
                    User.SavedVocabularies = vocabularies;

                    User.SavedVocabularies.Add(vocab);
                    userFound = true;
                    break;
                }
            }
        }
        else
        {
            vocabFound = false;
        }

        var result = JsonConvert.SerializeObject(Users, Formatting.Indented);
        File.WriteAllText(Path.PathUser, result);

        return (userFound, vocabFound);
    }
    public User Create(User user)
    {
        users.Add(user);
        var content = JsonConvert.SerializeObject(users, Formatting.Indented);
        File.WriteAllText(Path.PathUser, content);
        return user;
    }
    public bool Delete(int id)
    {
        var content = File.ReadAllText(Path.PathUser);
        List<User> Users = JsonConvert.DeserializeObject<List<User>>(content);

        foreach (var item in Users)
        {
            if (item.Id == id)
            {
                Users.Remove(item);
                break;
            }
        }
        var result = JsonConvert.SerializeObject(Users, Formatting.Indented);
        File.WriteAllText(Path.PathUser, result);

        return true;
    }
    public List<User> GetAll()
    {
        var content = File.ReadAllText(Path.PathUser);
        return JsonConvert.DeserializeObject<List<User>>(content);
    }
    public User GetById(int id)
    {
        var user = GetAll().FirstOrDefault(user => user.Id == id);
        return user;
    }
    public User Update(int id, User user)
    {
        var content = File.ReadAllText(Path.PathUser);
        List<User> Users = JsonConvert.DeserializeObject<List<User>>(content);

        foreach (var item in Users)
        {
            if (item.Id == id)
            {
                item.Name = user.Name;
                break;
            }
        }
        var result = JsonConvert.SerializeObject(Users, Formatting.Indented);
        File.WriteAllText(Path.PathUser, result);

        return user;
    }
}
