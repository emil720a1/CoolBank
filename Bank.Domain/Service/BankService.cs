using Bank.Domain.Accounts;

namespace Bank.Domain.Service;

public class BankService
{
    private readonly List<Account> _accounts;

    private int _nextAccountId = 1;
    
    public BankService()
    {
        _accounts = new List<Account>();
        
    }

    public Account OpenAccount(string owner, decimal balance, string name)
    {
        var id = _nextAccountId++;
        var account = new SavingAccount(id, name, owner, balance);
        
        _accounts.Add(account);
        return account;
    }



    public void Transfer(int fromId, int toId, decimal amount)
    {
        if (amount <= 0)
        {
            throw new ArgumentNullException(nameof(amount));
        }
        var fromAccount = GetAccountById(fromId);
        var toAccount = GetAccountById(toId);

        if (fromAccount == null || toAccount == null)
        {
            throw new ArgumentException("Account not found");
        }
        fromAccount?.Withdraw(amount);
        toAccount?.Deposit(amount);
    }

    public Account? GetAccountById(int id) => _accounts.FirstOrDefault(x => x.Id == id);
    

    public void GetAccountsInfo()
    {
        foreach (var account in _accounts)
        {
            Console.WriteLine($"Id: {account.Id} Name: {account.Name} Owner: {account.Owner} StartBalane: {account.Balance}");
        }
    }
    
}