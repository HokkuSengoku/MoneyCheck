using System.ComponentModel.DataAnnotations;

namespace MoneyCheck.Models;

public class User
{
    public int Id { get; set; }
    public string UserName { get; set; }
    public decimal Balance { get; set; }
    public List<Account> UserAccounts { get; set; } = new List<Account>();
}