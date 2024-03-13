namespace VendingMachine.Logic;

public class Coin
{
    public int Parse(string input)
    {
        var validCoins = new string[] { "10C", "20C", "50C", "1E", "2E" };

        bool inputIsValid = false;
        foreach(var coinString in validCoins)
        {
            if(input == coinString)
            {
                inputIsValid = true;
            }
        }
        if(!inputIsValid)
        {
            throw new FormatException("Invalid coin.");
        }

        var coin = int.Parse(input.Remove(input.Length-1));
        if (coin < 10)
        {
            coin *= 100;
        }

        return coin;
    }
}
