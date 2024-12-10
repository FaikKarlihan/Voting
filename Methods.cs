public static class Methods
{
    
    public static void register(string inputUsername)
    {
        VotingSystem obj = VotingSystem.Instance;
        string reply;
        Console.Clear();
        Console.WriteLine("There is no member with this name. Would you like to become a member with this name?");
        Console.WriteLine("Press (1) to accept or any key to exit");
        reply = Console.ReadLine();
        switch (reply)
        {
            case "1":
            obj.registerUser(inputUsername);  
            break;          

            default:
            Environment.Exit(0);
            break;
        }
    }
    public static void printCategories()
    {
        VotingSystem obj = VotingSystem.Instance;
        foreach (var item in obj.Categories)
        {
           Console.WriteLine($"{item.GetNanme()} -{item.GetId()}");
        }
    }

    public static string ValidNameCheck(string name)
    {
        while (true)
        {
            if (!string.IsNullOrWhiteSpace(name))
            {
                return name.Trim();
            }
            Console.Write("Please enter a valid name: "); name = Console.ReadLine();            
        }
    }
    public static bool userCheck_Add(string username)
    {
        VotingSystem obj = VotingSystem.Instance;
        User? foundUser = obj.findUserByUserName(username);

        if (foundUser != null)
        {
            if (foundUser.GetCategory() != null)
            {
            Console.WriteLine("User has already voted. Press any key");
            Console.ReadKey();
            return false;
            }
            return true;
        }
        else
        {
            register(username);
            return false;
        }
    }
    public static string selectCategory()
    {
        while (true)
        {
            VotingSystem obj = VotingSystem.Instance;
            bool find = false;
            string id;
            Console.Clear();
            Console.WriteLine("Please enter the ID of the category you want to vote for.\n");
            printCategories();
            Console.Write("ID: "); id=Console.ReadLine();
            foreach (var item in obj.Categories)
            {
                if (id.Equals(item.GetId().ToString()))
                {
                    return id;
                }
            }
            if (!find)
            {
                Console.WriteLine("Invalid ID. Please choose an ID from the available categories.\nPress any key");
                Console.ReadKey();
            }            
        }
    }
}