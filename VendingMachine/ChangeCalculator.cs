using System.Security.Authentication.ExtendedProtection;
namespace VendingMachine.Logic;

public class ChangeCalculator(int productPrice)
{
    public int ProductPrice { get; set; } = productPrice;
    public int Sum { get; set; }
    public bool IsEnoughMoney => TotalAmount >= ProductPrice;
    public int TotalAmount { get; private set; }

    // takes a coin value in Cents as input and adds it to the total amount.
    public int AddCoin(int coin)
    {
        return checked(TotalAmount += coin);
    }

    // returns the change to be returned to the user. If the total amount is less than the product price, the method should throw an InvalidOperationException exception.
    public int GetChange()
    {
        if(!IsEnoughMoney)
        {
            throw new InvalidOperationException();
        }
        var change = TotalAmount - ProductPrice;
        TotalAmount = 0;
        return change;
    }
}
