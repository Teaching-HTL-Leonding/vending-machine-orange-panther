namespace VendingMachine.Logic;

public static class Coin
{
    public static int Parse(string input)
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

    public static int ParseAny(string coin)
        => coin[^1] == 'E' ? (int)(decimal.Parse(coin[..^1]) * 100) : int.Parse(coin[..^1]);
}
