class User
{
    private int id;
    private string username;
    private bool hasVoted;
    private static int idCounter = 0;
    public Category? VotedCategory { get; private set; }


    public int GetId() => id;
    public string GetUsername() => username;
    public Category? GetCategory() => VotedCategory;


    public User(string username)
    {
        this.id = ++idCounter;
        this.username = username;
        this.hasVoted = false;
    }
    public void SetVotedCategory(Category category)
    {
        if (!hasVoted)
        {
            VotedCategory = category;
            hasVoted = true;
        }
        else
        {
            Console.WriteLine("User has already voted.");
        }
    }
}
