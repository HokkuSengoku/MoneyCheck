namespace MoneyCheck.Models;

public class Category
{
    public int CategoryId { get; set; }
    public List<string> Categories { get; set; } = new List<string>();
    public int AccountId { get; set; }
    public Account AccountNavigation { get; set; }
}