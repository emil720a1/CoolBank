namespace Bank.Domain.Accounts;

public class SavingAccount : Account
{
    public SavingAccount(int id, string name, string owner, decimal startBalance = 0m) 
        : base(id, name, owner, startBalance)
    {
        
    }
    
    
    
}