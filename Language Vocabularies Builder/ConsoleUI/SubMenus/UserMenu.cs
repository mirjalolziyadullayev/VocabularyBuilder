using Spectre.Console;
using VocabularyBuilder.Models;
using VocabularyBuilder.Services;
namespace Language_Vocabularies_Builder.ConsoleUI.SubMenus;
public class UserMenu
{
    private readonly UserService userService;
    public UserMenu()
    {
        userService = new UserService();
    }
    public void Display()
    {
        while (true)
        {
            AnsiConsole.Write(new Markup("[green]Vocabulary[/][grey]Builder[/]\n"));
            AnsiConsole.Write(new Markup("[blue]User Menu[/]\n\n"));
            AnsiConsole.Write(new Markup("[white]  1.Create[/]\n"));
            AnsiConsole.Write(new Markup("[white]  2.Update[/]\n\n"));
            AnsiConsole.Write(new Markup("[white]  3.Delete[/]\n\n"));
            AnsiConsole.Write(new Markup("[white]  4.Get by Id[/]\n\n"));
            AnsiConsole.Write(new Markup("[white]  5.Get All[/]\n\n"));
            AnsiConsole.Write(new Markup("[white]  6.Add vocabulary[/]\n\n"));
            AnsiConsole.Write(new Markup("[red]  3.Exit[/]\n"));
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
                    AddVocabulary();
                    Console.WriteLine();
                    return;
                case "7":
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

    private void AddVocabulary()
    {
        Console.WriteLine("Create Note");
        Console.WriteLine("Enter User Id:");
        int UserId;
        while (!int.TryParse(Console.ReadLine(), out UserId))
        {
            Console.WriteLine("Press any key to re-enter");
        }
        Console.WriteLine("Enter Vocabulary Id:");
        int VocabularyId;

        while (!int.TryParse(Console.ReadLine(), out VocabularyId))
        {
            Console.WriteLine("Press any key to re-enter");
        }

        userService.AddVocabulary(UserId, VocabularyId);

        Console.WriteLine("Note created!");
    }
    private void Create()
    {
        Console.WriteLine("Create User");
        Console.WriteLine("Enter Id:");
        int id;
        while (!int.TryParse(Console.ReadLine(), out id))
        {
            Console.WriteLine("Press any key to re-enter");
        }
        Console.Write("Enter user Name: ");
        string name = Console.ReadLine();
        while (string.IsNullOrWhiteSpace(name))
        {
            Console.WriteLine("Press any key to re-enter");
            name = Console.ReadLine();
        }
        var newUser = new User
        {
            Id = id,
            Name = name,
        };

        userService.Create(newUser);
        Console.WriteLine("User created successfully.");
    }
    private void Update()
    {
        Console.WriteLine("Update User");
        Console.WriteLine("Enter id:");
        int userId;
        while (!int.TryParse(Console.ReadLine(), out userId))
        {
            Console.WriteLine("Press any key to re-enter");
        }
        var existUser = userService.GetById(userId);
        if (existUser != null)
        {
            Console.WriteLine("Enter update Name:");
            string updatedName = Console.ReadLine();
            while (string.IsNullOrWhiteSpace(updatedName))
            {
                Console.WriteLine("Press any key to re-enter");
                updatedName = Console.ReadLine();
            }
            var user = userService.GetById(userId);
            if (user != null)
            {
                user.Name = updatedName;
                userService.Update(userId, user);
                Console.WriteLine("User updated successfully");
            }
            else
            {
                Console.WriteLine("User is not found");
            }
        }
    }
    private void Delete()
    {
        Console.WriteLine("Delete User");
        Console.WriteLine("Enter an Id");
        int id;
        while (!int.TryParse(Console.ReadLine(), out id))
        {
            Console.WriteLine("Press any key to re-enter");
        }
        if (userService.Delete(id))
        {
            Console.WriteLine("User deleted successfully");
        }
        else
        {
            Console.WriteLine($"User with Id {id} not found");
        }
    }
    private void GetById()
    {
        Console.WriteLine("Get By Id");
        Console.WriteLine("Enter an Id:");
        int id;
        while (!int.TryParse(Console.ReadLine(), out id))
        {
            Console.WriteLine("Press any key to re-enter");
        }
        var user = userService.GetById(id);
        if (user == null)
        {
            Console.WriteLine("User is not found");
        }
        else Console.WriteLine($"Id:{user.Id} | Name {user.Name} ");
    }
    private void GetAll()
    {
        Console.WriteLine("Get all User");
        IEnumerable<User> users = userService.GetAll();
        if (users.Count() > 0)
        {
            foreach (var user in users)
            {
                Console.WriteLine($"Id:{user.Id} | {user.Name}");
            }
        }
        else
        {
            Console.WriteLine("User not found");
        }

    }
}

