namespace Bank.Domain;

public abstract class Account : BankEntity
{
    private decimal Balance { get; set; }
    
    public string Owner { get; set; }

    protected Account(int id, string name, string owner, decimal startBalance = 0m) 
        : base(id, name)
    {
        Owner = owner;
        Balance = startBalance;
    }
    
    public virtual void Deposit(decimal amount)
    {
        if (amount <= 0)
        {
            throw new ArgumentOutOfRangeException(nameof(amount), "Amount must be positive");
        }
        Balance += amount;
    }

    public virtual void Withdraw(decimal amount)
    {

        if (amount <= 0)
        {
            throw new ArgumentOutOfRangeException(nameof(amount), "Amount must be positive");
        }

        if (amount > Balance)
        {
            throw new ArgumentOutOfRangeException(nameof(amount), "Amount must be less than Balance");
        }

        Balance -= amount;
    }

    public override void PrintResult()
    {
        Console.WriteLine($"Id: {Id}, Name: {Name}, Owner: {Owner}, Balance: {Balance}");
    }
}