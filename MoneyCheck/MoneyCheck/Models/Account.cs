using System.ComponentModel.DataAnnotations.Schema;

namespace MoneyCheck.Models;

public class Account
{
    public int Id { get; set; }
    public string AccountName { get; set; }
    public decimal AccountBalance { get; set; }
    public Category AccountCategories { get; set; } = new Category();
    public int UserId { get; set; }
    [ForeignKey(nameof(UserId))]
    public User UserNavigation { get; set; }
    public Category CategoryNavigation { get; set; }
}