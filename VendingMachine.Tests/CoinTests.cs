namespace VendingMachine.Tests;
using VendingMachine.Logic;

public class CoinTests
{
    [Theory]
    [InlineData("2E", 200)]
    [InlineData("1E", 100)]
    [InlineData("50C", 50)]
    [InlineData("20C", 20)]
    [InlineData("10C", 10)]
    public void ParseValidCoin_ShouldReturnValue(string coin, int value)
    {
        var result = Coin.Parse(coin);
        Assert.Equal(result, value);
    }

    [Theory]
    [InlineData("3E")]
    [InlineData("1D")]
    [InlineData("50")]
    [InlineData("20Cents")]
    public void ParseInvalidCoin_ShouldThrowFormatException(string coin)
    {
        Assert.Throws<FormatException>(() => Coin.Parse(coin));
    }
    // [Fact]
    // public void Parse_WhenCoinInputIsValid_ShouldReturnIntValue()
    // {
    //     var coin = new Coin();

    //     var result = coin.Parse("10C");
    //     Assert.Equal(10, result);
    //     result = coin.Parse("20C");
    //     Assert.Equal(20, result);
    //     result = coin.Parse("50C");
    //     Assert.Equal(50, result);
    //     result = coin.Parse("1E");
    //     Assert.Equal(100, result);
    //     result = coin.Parse("2E");
    //     Assert.Equal(200, result);
    // }

    // [Fact]
    // public void Parse_ThrowsFormatException_WhenInputInvalid()
    // {
    //     var coin = new Coin();
    //     Assert.Throws<FormatException>(() => coin.Parse("3E")); 
    //     Assert.Throws<FormatException>(() => coin.Parse("1D")); 
    //     Assert.Throws<FormatException>(() => coin.Parse("50")); 
    //     Assert.Throws<FormatException>(() => coin.Parse("20Cents")); 
    // }
}