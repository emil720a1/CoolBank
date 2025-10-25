using Bank.Domain.Accounts;

namespace Bank.Domain.Service;

public class BankService
{
    private readonly List<Account> _accounts;

    private readonly int _nextAccountId = 1;
    
    public BankService(int nextAccountId)
    {
        _accounts = new List<Account>();
        _nextAccountId = nextAccountId;
        
    }

    public Account OpenAccount(string owner, decimal balance, string name)
    {
        var id = nextAccountId++;
        var account = new SavingAccount(id, name, owner, balance);
        
        _accounts.Add(account);
        return account;
    }

    public Account? GetAccountById(int id) => _accounts.FirstOrDefault(x => x.Id == id);
        
    
    public List<Account> GetAccounts() => _accounts;
}