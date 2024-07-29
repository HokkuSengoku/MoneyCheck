using Microsoft.EntityFrameworkCore;

namespace MoneyCheck.Models;

public class Account
{
    public int UserId { get; set; }
    public User UserNavigation { get; set; }
    public int AccountId { get; set; }
    public string Name { get; set; }
    public decimal Balance { get; set; }
    private Category _category = new Category();
}