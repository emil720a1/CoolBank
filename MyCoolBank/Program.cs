using System.ComponentModel.Design;
using Bank.Domain;
using Bank.Domain.Service;

class Program
{
    static void Main(string[] args)
    {
    var bank = new BankService();

    while(true)
    {
           Console.WriteLine("1.Открыть счет");
           Console.WriteLine("2.Сделать перевод");
           Console.WriteLine("3.Показать все счета");
           Console.WriteLine("4.Выход");
           Console.WriteLine("Введите команду");

        
        int userInput = int.Parse(Console.ReadLine());
        if (userInput < 1 || userInput > 4)
        {
            continue;
        }
        switch (userInput)
        {
            case 1:
                
                Console.WriteLine("Введите ваше имя для открытия счета:");
                string ownerName = Console.ReadLine();

                Console.WriteLine("Для того чтобы использовать счёт, надо пополнить его на определенный баланс");
                Console.WriteLine("Введите сумму пополнения");
                decimal amount = decimal.Parse(Console.ReadLine());

                Console.WriteLine("Введите ваш псевдоним(Как к вам лучше обращаться):");
                string nickname = Console.ReadLine();

                if (string.IsNullOrEmpty(ownerName) || amount <= 0 || string.IsNullOrEmpty(nickname))
                {
                    break;
                }
                
                bank.OpenAccount(
                    ownerName, 
                    amount, 
                    nickname);

                Console.WriteLine("Счет успешно создан");
                Console.WriteLine($"Owner: {ownerName}, Amount: {amount}, Nickname: {nickname}");
                break;
            
            case 2:
                try
                {
                    Console.WriteLine("Введите ID своего аккаунта, из которого хотите совершить перевод:");
                    var fromId = int.Parse(Console.ReadLine());

                    Console.WriteLine("Введите ID аккаунта, на который вы хотите совершить перевод");
                    var toId = int.Parse(Console.ReadLine());

                    Console.WriteLine("Введите сумму которую вы хотите перевести");
                    var amountTransfer = decimal.Parse(Console.ReadLine());



                    bank.Transfer(fromId, toId, amountTransfer);
                    Console.WriteLine("Перевод успешно выполнился");
                }
                catch (Exception e)
                {
                    Console.WriteLine($"Ошибка: {e.Message}");
                }
                
                break;
            case 3:
                Console.WriteLine("Список всех счетов в банке:");
                bank.GetAccountsInfo();
                break;
            case 4:
                Console.WriteLine("Выход из программы");
                return;
        }
    }
}
    }
