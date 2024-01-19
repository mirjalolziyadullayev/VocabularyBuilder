using VocabularyBuilder.Models;
using VocabularyBuilder.Services;
namespace Language_Vocabularies_Builder.ConsoleUI.SubMenus;
public class VocabularyMenu
{
    private readonly VocabularyService vocabularyService;

    public VocabularyMenu()
    {
        vocabularyService = new VocabularyService();
    }
    public void Show()
    {
        while (true)
        {
            Console.WriteLine("Vocabulary Menu\n");
            Console.WriteLine("1.Create");
            Console.WriteLine("2.Update");
            Console.WriteLine("3.Delete");
            Console.WriteLine("4.Get By Id");
            Console.WriteLine("5.Get All");
            Console.WriteLine("6.Exit");
            Console.WriteLine("Choose an option");
            string choice = Console.ReadLine();
            while (string.IsNullOrWhiteSpace(choice))
            {
                Console.WriteLine("Choose a valid option");
                choice = Console.ReadLine();
            }
            switch (choice)
            {
                case "1":
                    Console.Clear();
                    Create();
                    Console.WriteLine();
                    break;
                case "2":
                    Console.Clear();
                    Update();
                    Console.WriteLine();
                    break;
                case "3":
                    Console.Clear();
                    Delete();
                    Console.WriteLine();
                    break;
                case "4":
                    GetById();
                    Console.WriteLine();
                    break;
                case "5":
                    Console.Clear();
                    GetAll();
                    Console.WriteLine();
                    break;
                case "6":
                    Console.Clear();
                    Console.WriteLine("Exit");
                    Console.WriteLine();
                    return;
                default:
                    Console.Clear();
                    Console.WriteLine("Invalid choice, press any key to re-enter");
                    Console.WriteLine();
                    break;

            }
        }
    }
    private void GetById()
    {
        Console.WriteLine("====Get By Id====");
        Console.WriteLine("Enter the Id:");
        int id;
        while (!int.TryParse(Console.ReadLine(), out id))
        {
            Console.WriteLine("Enter a valid id");
        }
        var vocabulary = vocabularyService.GetById(id);
        if (vocabulary == null)
        {
            Console.WriteLine("Vocabulary not found");
        }
        else Console.WriteLine($"Id:{vocabulary.Id}|{vocabulary.Language}|{vocabulary.TranslateLanguage}Word: {vocabulary.Word}");
    }
    private void Create()
    {
        Console.WriteLine("\n=== Create Vocabulary ===");
        Console.WriteLine("Enter Id:");
        int id;
        while (!int.TryParse(Console.ReadLine(), out id))
        {
            Console.WriteLine("Enter a valid id");
        }
        Console.WriteLine("Enter language: ");
        string language = Console.ReadLine();
        while (string.IsNullOrWhiteSpace(language))
        {
            Console.Write("Enter valid input: ");
            language = Console.ReadLine();
        }
        Console.WriteLine("Enter Translate Language[English-Uzbek]: ");
        string translateLanguage = Console.ReadLine();
        while (string.IsNullOrWhiteSpace(translateLanguage))
        {
            Console.Write("Enter valid input: ");
            translateLanguage = Console.ReadLine();
        }
        Console.WriteLine("Enter Word: ");
        string word = Console.ReadLine();
        while (string.IsNullOrWhiteSpace(word))
        {
            Console.Write("Enter valid input: ");
            word = Console.ReadLine();
        }

        var newVocab = new Vocabulary
        {
            Id = id,
            Language = language,
            TranslateLanguage = translateLanguage,
            Word = word,
        };
        vocabularyService.Create(newVocab);
        Console.WriteLine("Vocabulary created.");
    }
    private void Update()
    {
        Console.WriteLine("Update Vocabulary\n");
        Console.WriteLine("Enter id:");
        int vocabularyId;
        while (!int.TryParse(Console.ReadLine(), out vocabularyId))
        {
            Console.WriteLine("Enter a valid Id:");
        }
        var existVocabulary = vocabularyService.GetById(vocabularyId);
        if (existVocabulary != null)
        {
            Console.WriteLine("Enter update Language:");
            string updatedLanguage = Console.ReadLine();
            while (string.IsNullOrWhiteSpace(updatedLanguage))
            {
                Console.WriteLine("Enter a valid langauge ");
                updatedLanguage = Console.ReadLine();
            }
            Console.WriteLine("Enter update Translate Language:");
            string updatedTranslateLanguage = Console.ReadLine();
            while (string.IsNullOrWhiteSpace(updatedTranslateLanguage))
            {
                Console.WriteLine("Enter a valid langauge ");
                updatedLanguage = Console.ReadLine();
            }

            Console.WriteLine("Enter update Word:");
            string updatedWord = Console.ReadLine();
            while (string.IsNullOrWhiteSpace(updatedWord))
            {
                Console.WriteLine("Enter a valid word");
                updatedWord = Console.ReadLine();
            }
            Console.WriteLine("Enter update Definition:");
            string updatedDefinition = Console.ReadLine();
            while (string.IsNullOrWhiteSpace(updatedDefinition))
            {
                Console.WriteLine("Enter a valid Definition");
                updatedWord = Console.ReadLine();
            }
            Console.WriteLine("Enter update Synonyms:");
            string updatedSynonyms = Console.ReadLine();
            while (string.IsNullOrWhiteSpace(updatedSynonyms))
            {
                Console.WriteLine("Enter a valid Synonyms");
                updatedSynonyms = Console.ReadLine();
            }
            Console.WriteLine("Enter update Example:");
            string updatedExample = Console.ReadLine();
            while (string.IsNullOrWhiteSpace(updatedExample))
            {
                Console.WriteLine("Enter a valid word");
                updatedExample = Console.ReadLine();
            }
            var vocabulary = vocabularyService.GetById(vocabularyId);
            if (vocabulary != null)
            {
                vocabulary.Language = vocabulary.Language;
                vocabulary.TranslateLanguage = vocabulary.TranslateLanguage;
                vocabulary.Word = updatedWord;

                vocabularyService.Update(vocabularyId, vocabulary);
                Console.WriteLine("Vocabulary updated");
            }
            else
            {
                Console.WriteLine("Vocabulary is not found");
            }
        }
    }
    private void Delete()
    {
        Console.WriteLine("Delete Vocabulary");
        Console.WriteLine("Enter vocabularyId to delete");
        int id;
        while (!int.TryParse(Console.ReadLine(), out id))
        {
            Console.WriteLine("Please enter a valid id");
        }
        if (vocabularyService.Delete(id))
        {
            Console.WriteLine("User deleted successfully");
        }
        else
        {
            Console.WriteLine($"User with Id {id} not found");
        }
    }
    private void GetAll()
    {
        Console.WriteLine("Get All Vocabularies");
        IEnumerable<Vocabulary> vocabularies = vocabularyService.GetAll();
        if (vocabularies.Count() > 0)
        {
            foreach (var vocabulary in vocabularies)
            {
                Console.WriteLine($"Id:{vocabulary.Id}\nLanguage:{vocabulary.Language}\nTranslateLanguage:{vocabulary.TranslateLanguage}\nWord:{vocabulary.Word}");
            }
        }
        else
        {
            Console.WriteLine("Vocabulary not found");
        }
    }
}
