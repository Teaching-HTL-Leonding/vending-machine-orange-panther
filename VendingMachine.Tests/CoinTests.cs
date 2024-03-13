namespace VendingMachine.Tests;
using VendingMachine.Logic;

public class CoinTests
{
    [Fact]
    public void Parse_WhenCoinInputIsValid_ShouldReturnIntValue()
    {
        var coin = new Coin();

        var result = coin.Parse("10C");
        Assert.Equal(10, result);
        result = coin.Parse("20C");
        Assert.Equal(20, result);
        result = coin.Parse("50C");
        Assert.Equal(50, result);
        result = coin.Parse("1E");
        Assert.Equal(100, result);
        result = coin.Parse("2E");
        Assert.Equal(200, result);
    }

    [Fact]
    public void Parse_ThrowsFormatException_WhenInputInvalid()
    {
        var coin = new Coin();
        Assert.Throws<FormatException>(() => coin.Parse("3E")); 
        Assert.Throws<FormatException>(() => coin.Parse("1D")); 
        Assert.Throws<FormatException>(() => coin.Parse("50")); 
        Assert.Throws<FormatException>(() => coin.Parse("20Cents")); 
    }
}