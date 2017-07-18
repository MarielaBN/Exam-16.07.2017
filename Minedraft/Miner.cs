public abstract class Miner
{
    private string id;

    protected Miner(string id)
    {
        this.id = id;
    }

    public string Id { get; set; }
}