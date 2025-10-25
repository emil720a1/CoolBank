using Bank.Domain;
using Bank.Domain.Service;

class Program
{
    static void Main(string[] args)
    {

        var bank = new BankService();

        bank.OpenAccount(
            "Oleg", 
            1000m, 
            "McOleg");

       Account? account = bank.GetAccountById(1);
       Console.WriteLine(account);
    }
}