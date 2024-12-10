using System.Reflection.Metadata;
using static Methods;
class VotingSystem
{
    private static VotingSystem _instance;
    private List<Category> categories{get;set;} = new List<Category>();
    private List<User> users{get;set;} = new List<User>();


    public IReadOnlyList<Category> Categories => categories;


    public static VotingSystem Instance
    {
        get
        {
           if (_instance == null)
           {
              _instance = new VotingSystem();
           }
           return _instance;
        }
    }


    public VotingSystem()
    {
        categories.Add(new Category(1, "Movie"));
        categories.Add(new Category(2, "Tech Stack"));
        categories.Add(new Category(3, "Sport"));
        categories.Add(new Category(4, "Art"));
        categories.Add(new Category(5, "Science"));

        users.Add(new User("han"));
    }


    public User? findUserByUserName(string username)
    {
        foreach (var item in users)
        {
            if (username.Equals(item.GetUsername()))
            {
                return item;
            }
        }
        return null;
    }
    public void registerUser(string username)
    {
        User user = findUserByUserName(username);
        if (user==null)
        {
            User newUser = new User(username);
            users.Add(newUser);
            Console.WriteLine("Successfully registered...Press any key");
            Console.ReadKey();
            Console.Clear();
        }
        else
        {
            Console.WriteLine("There is already a member with this name...Press any key");
            Console.ReadKey();
            Console.Clear();
        }

    }
    public void addVote(int categoryId, string username)
    {
        Category category = Categories.FirstOrDefault(c => c.GetId() == categoryId);
        category.addVote();

        User user = findUserByUserName(username);
        user.SetVotedCategory(category);
    }
    public void displayResults()
    {
        Console.Clear();
        int total = 0;
        foreach (var category in categories)
        {
            total += category.GetVotes();
        }
        if (total == 0)
        {
            Console.WriteLine("No votes have been cast yet.\nPress any key");
            Console.ReadKey();
            return;
        }
        foreach (var item in categories)
        {
            double rate = (double)item.GetVotes() / total * 100;
            Console.WriteLine(item.GetNanme() + $"\nVote: {item.GetVotes()}  Rate: %{rate:F2}\n");
        }
        Console.WriteLine("Press any key");
        Console.ReadKey();
    }
}


