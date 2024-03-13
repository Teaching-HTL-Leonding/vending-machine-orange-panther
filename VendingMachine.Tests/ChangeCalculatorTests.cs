namespace VendingMachine.Tests;
using VendingMachine.Logic;

public class ChangeCalculatorTests
{
    [Fact]
    public void InitializeChangeCalculator_TotalAmountIsInitiallyZero()
    {
        var cc = new ChangeCalculator(100);
        Assert.Equal(0, cc.TotalAmount);
    }

    [Fact]
    public void AddCoin_WhenCalledWithValidInput_AddToTotalAmount()
    {
        var cc = new ChangeCalculator(100);

        cc.AddCoin(50);
        Assert.Equal(50, cc.TotalAmount);

        cc.AddCoin(50);
        Assert.Equal(100, cc.TotalAmount);
    }

    [Fact]
    public void AddCoin_ThrowsOverflowException_WhenTotalAmountExceedsMaxValue()
    {
        var cc = new ChangeCalculator(100);

        cc.AddCoin(int.MaxValue);
        Assert.Throws<OverflowException>(() => cc.AddCoin(1));
    }

    [Fact]
    public void TotalAmountEqualOrGreaterThanPrice_IsEnoughMoneyReturnsTrue()
    {
        var cc = new ChangeCalculator(100);
        cc.AddCoin(100);
        Assert.True(cc.IsEnoughMoney);
    }

    [Fact]
    public void TotalAmountLessThanPrice_IsEnoughMoneyReturnsFalse()
    {
        var cc = new ChangeCalculator(100);
        cc.AddCoin(50);
        Assert.False(cc.IsEnoughMoney);
    }

    [Fact]
    public void GetChangeSucceeds_ReturnsCorrectChange()
    {
        var cc = new ChangeCalculator(100);

        cc.AddCoin(100);
        var change = cc.GetChange();
        Assert.Equal(0, change);
        Assert.Equal(0, cc.TotalAmount);

        cc.AddCoin(250);
        change = cc.GetChange();
        Assert.Equal(150, change);
        Assert.Equal(0, cc.TotalAmount);
    }

    [Fact]
    public void GetChangeFails_ThrowsInvalidOperationException()
    {
        var cc = new ChangeCalculator(100);
        Assert.Throws<InvalidOperationException>(() => cc.GetChange());

        cc.AddCoin(50);
        Assert.Throws<InvalidOperationException>(() => cc.GetChange());
    }

}