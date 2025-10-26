namespace Bank.Domain;

public abstract class BankEntity 
{
    public int Id { get; private set; }
    
    public string Name  { get; private set; }

    public BankEntity(int id, string name)
    {
        Id = id;
        Name = name;
    }
    
    public abstract void PrintResult();
    
}