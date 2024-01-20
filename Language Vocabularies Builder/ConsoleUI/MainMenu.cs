using VocabularyBuilder.Services;
namespace VocabularyBuilder.Menu;

using Language_Vocabularies_Builder.ConsoleUI.SubMenus;
using Spectre.Console;

public class MainMenu
{
    private readonly UserMenu userMenu;
    private readonly VocabularyMenu vocabularyMenu;

    private readonly UserService userService;
    private readonly VocabularyService vocabularyService;

    public MainMenu()
    {
        userService = new UserService();
        vocabularyService = new VocabularyService();

        userMenu = new UserMenu();
        vocabularyMenu = new VocabularyMenu();
    }

    public void Display()
    {
        while (true)
        {
            Console.Clear();
            AnsiConsole.Write(new Markup("[green]Vocabulary[/][grey]Builder[/]\n"));
            AnsiConsole.Write(new Markup("[blue]====MainMenu=====[/]\n\n"));
            AnsiConsole.Write(new Markup("[white]1.UserMenu[/]\n"));
            AnsiConsole.Write(new Markup("[white]2.VocabularyMenu[/]\n\n"));
            AnsiConsole.Write(new Markup("[red]3.Exit[/]\n"));
            Console.WriteLine("Enter your choice:");
            string choice = Console.ReadLine();
            while (string.IsNullOrWhiteSpace(choice))
            {
                Console.WriteLine("Enter a valid choice");
                choice = Console.ReadLine();
            }
            switch (choice)
            {
                case "1":
                    Console.Clear();
                    userMenu.Display();
                    Console.WriteLine();
                    break;
                case "2":
                    Console.Clear();
                    vocabularyMenu.Display();
                    Console.WriteLine();
                    break;
                case "3":
                    Console.Clear();
                    Console.WriteLine("Exit...");
                    Environment.Exit(0);
                    break;
                default:
                    Console.Clear();
                    Console.WriteLine("Invalid choice, press any key to re-enter...");
                    Console.WriteLine();
                    break;
            }
        }
    }
}
