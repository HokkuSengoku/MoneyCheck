namespace MoneyCheck.Models;

public class User
{
    public string UserName { get; set; }
    public decimal UserBalance { get; set; } 
    public int UserId { get; set; }

    public IEnumerable<Account> Accounts { get; set; } = new List<Account>();

}