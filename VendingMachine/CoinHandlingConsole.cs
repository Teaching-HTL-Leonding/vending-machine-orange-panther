namespace VendingMachine.Logic;

public class CoinHandlingConsole()
{
    // return change to be returned to the user
    public int HandleCoins()
    {
        Console.Write("Price: ");
        var priceString = Console.ReadLine()!;
        var price = double.Parse(priceString.Remove(priceString.Length - 1)) * 100;
        var cc = new ChangeCalculator((int)price);


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
