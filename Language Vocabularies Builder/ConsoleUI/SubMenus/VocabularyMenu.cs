using Spectre.Console;
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
    public void Display()
    {
        while (true)
        {
            AnsiConsole.Write(new Markup("[green]Vocabulary[/][grey]Builder[/]\n"));
            AnsiConsole.Write(new Markup("[blue]Vocabulary Menu[/]\n\n"));
            AnsiConsole.Write(new Markup("[white]  1.Create[/]\n"));
            AnsiConsole.Write(new Markup("[white]  2.Update[/]\n\n"));
            AnsiConsole.Write(new Markup("[white]  3.Delete[/]\n\n"));
            AnsiConsole.Write(new Markup("[white]  4.Get by Id[/]\n\n"));
            AnsiConsole.Write(new Markup("[white]  5.Get All[/]\n\n"));
            AnsiConsole.Write(new Markup("[red]  6.Exit[/]\n"));
            Console.WriteLine("Enter your choice:");
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
        Console.WriteLine("Get by Id");
        Console.WriteLine("Enter the Id:");
        int id;
        while (!int.TryParse(Console.ReadLine(), out id))
        {
            Console.WriteLine("Press any key to re-enter");
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
        Console.WriteLine("Create Vocabulary");
        Console.WriteLine("Press any key to re-enter");
        int id;
        while (!int.TryParse(Console.ReadLine(), out id))
        {
            Console.WriteLine("Press any key to re-enter");
        }
        Console.WriteLine("Enter language: ");
        string language = Console.ReadLine();
        while (string.IsNullOrWhiteSpace(language))
        {
            Console.WriteLine("Press any key to re-enter");
            language = Console.ReadLine();
        }
        Console.WriteLine("Enter Translate Language:");
        string translateLanguage = Console.ReadLine();
        while (string.IsNullOrWhiteSpace(translateLanguage))
        {
            Console.WriteLine("Press any key to re-enter");
            translateLanguage = Console.ReadLine();
        }
        Console.WriteLine("Enter Word: ");
        string word = Console.ReadLine();
        while (string.IsNullOrWhiteSpace(word))
        {
            Console.WriteLine("Press any key to re-enter");
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
            Console.WriteLine("Press any key to re-enter");
        }
        var existVocabulary = vocabularyService.GetById(vocabularyId);
        if (existVocabulary != null)
        {
            Console.WriteLine("Enter update Language:");
            string updatedLanguage = Console.ReadLine();
            while (string.IsNullOrWhiteSpace(updatedLanguage))
            {
                Console.WriteLine("Press any key to re-enter");
                updatedLanguage = Console.ReadLine();
            }
            Console.WriteLine("Enter update Translate Language:");
            string updatedTranslateLanguage = Console.ReadLine();
            while (string.IsNullOrWhiteSpace(updatedTranslateLanguage))
            {
                Console.WriteLine("Press any key to re-enter");
                updatedLanguage = Console.ReadLine();
            }
            Console.WriteLine("Enter update Word:");
            string updatedWord = Console.ReadLine();
            while (string.IsNullOrWhiteSpace(updatedWord))
            {
                Console.WriteLine("Press any key to re-enter");
                updatedWord = Console.ReadLine();
            }
            Console.WriteLine("Enter update Definition:");
            string updatedDefinition = Console.ReadLine();
            while (string.IsNullOrWhiteSpace(updatedDefinition))
            {
                Console.WriteLine("Press any key to re-enter");
                updatedWord = Console.ReadLine();
            }
            Console.WriteLine("Enter update Synonyms:");
            string updatedSynonyms = Console.ReadLine();
            while (string.IsNullOrWhiteSpace(updatedSynonyms))
            {
                Console.WriteLine("Press any key to re-enter");
                updatedSynonyms = Console.ReadLine();
            }
            Console.WriteLine("Enter update Example:");
            string updatedExample = Console.ReadLine();
            while (string.IsNullOrWhiteSpace(updatedExample))
            {
                Console.WriteLine("");
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
        Console.WriteLine("Enter an Id");
        int id;
        while (!int.TryParse(Console.ReadLine(), out id))
        {
            Console.WriteLine("Enter a valid id");
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
            Console.WriteLine("Vocabulary is not found");
        }
    }
}
