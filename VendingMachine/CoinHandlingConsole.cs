namespace VendingMachine.Logic;

public class CoinHandlingConsole()
{
    public virtual void WriteLine(string s) => Console.WriteLine(s);
    public virtual string ReadLine() => Console.ReadLine()!;
    // return change to be returned to the user
    public int HandleCoins()
    {
        Console.Write("Price: ");
        var cc = new ChangeCalculator(Coin.ParseAny(ReadLine()));

        while (!cc.IsEnoughMoney)
        {
            try
            {
                Console.Write("Coin: ");
                cc.AddCoin(Coin.Parse(Console.ReadLine()!));
                Console.WriteLine($"Total: {(double)cc.TotalAmount / 100d}E");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"{ex.Message}");
            }
        }
        var change = cc.GetChange();
        Console.WriteLine($"Change: {(double)change / 100d}E");
        return change;
    }
}
