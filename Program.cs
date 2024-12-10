using System.Net.NetworkInformation;
using static Methods;

string reply;
Console.Clear();
VotingSystem obj = VotingSystem.Instance;
Console.WriteLine("Note: Each user can vote only once");

while (true)
{
    Console.WriteLine("Please select the action you want to take\n");
    Console.WriteLine("Sign up(1)");
    Console.WriteLine("Vote(2)");
    Console.WriteLine("View current votes(3)");
    Console.WriteLine("Exit(0)");
    reply = Console.ReadLine();

    switch (reply)
    {
        case "1":
        Console.Clear();
        Console.WriteLine("Please enter username:");
        string? input = Console.ReadLine();
        string newMember = ValidNameCheck(input);
        obj.registerUser(newMember);

        break;

        case "2":
        Console.Clear();
        Console.WriteLine("Please enter username:");
        string? inputUsername = Console.ReadLine();
        string ValidName = ValidNameCheck(inputUsername);
        if (userCheck_Add(ValidName))
        {
            int selectedCategoryID = Convert.ToInt32(selectCategory());
            obj.addVote(selectedCategoryID, ValidName);
            Console.WriteLine("Voting successful...Press any key");
            Console.ReadKey();
        }
        Console.Clear();
        break;

        case "3":
        obj.displayResults();
        Console.Clear();
        break;

        case "0":
        Environment.Exit(0);
        break;

        default:
        Console.Clear();
        break;
    }

}