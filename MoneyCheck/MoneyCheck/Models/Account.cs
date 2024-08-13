using System.ComponentModel.DataAnnotations.Schema;

namespace MoneyCheck.Models;

public class Account
{
    public int Id { get; set; }
    public string AccountName { get; set; }
    public decimal AccountBalance { get; set; }
    public List<Category> AccountCategories { get; set; } = new List<Category>();
    public int UserId { get; set; }
    [ForeignKey(nameof(UserId))]
    public User User { get; set; }
}