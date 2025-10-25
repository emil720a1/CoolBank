namespace Bank.Domain.Accounts;

public class CheckingAccount : Account
{
    public CheckingAccount(int id, string name, string owner, decimal startBalance = 0m) 
        : base(id, name, owner, startBalance)
    {
        
    }
}