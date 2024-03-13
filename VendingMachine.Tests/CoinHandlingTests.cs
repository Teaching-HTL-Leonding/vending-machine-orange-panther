namespace VendingMachine.Tests;

public class CoinHandlingConsoleTests
{
    [Fact]
    public void OnlyValidCoinsEntered_ProductPriceReachedExactly_ChangeShouldBeZero()
    {
        var chc = new CoinHandlingConsoleMock(["1,5E", "1E", "50C"]);
        var result = chc.HandleCoins();
        Assert.Equal("Change: 0E", chc.Outputs.Last());
    }

    [Fact]
    public void OnlyValidCoinsEnteredProductPriceExceeded_ChangeShouldNotBeZero()
    {
        var chc = new CoinHandlingConsoleMock(["1,5E", "1E", "2E"]);
        var result = chc.HandleCoins();
        Assert.Equal("Change: 1,5E", chc.Outputs.Last());
    }

    [Fact]
    public void InvalidCoinEntered_ShouldPrintInvalidCoin()
    {
        var chc = new CoinHandlingConsoleMock(["1,5E", "3E", "1E", "50C"]);
        var result = chc.HandleCoins();
        Assert.Equal("Invalid coin.", chc.Outputs[2]);
    }
}
