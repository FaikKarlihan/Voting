class Category
{
    private int id;
    private int votes; 
    private string name;


    public int GetId() => id;
    public string GetNanme() => name;
    public int GetVotes() => votes;

    
    public Category(int id, string name)
    {
        this.id = id;
        this.name = name;
        this.votes = 0;
    }
    public void addVote()
    {
        votes++;
    }

}