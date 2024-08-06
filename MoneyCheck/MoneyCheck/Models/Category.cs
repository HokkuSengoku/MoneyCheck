using System.ComponentModel.DataAnnotations.Schema;

namespace MoneyCheck.Models;

public class Category
{
    public string CategoryName { get; set; }
    public int CategoryId { get; set; }
    public decimal CategorySum { get; set; }
    public DateTime CategoryOperationDate { get; set; }
    public List<Operation> CategoryOperations { get; set; } = new List<Operation>();
    public int AccountId { get; set; }
    [ForeignKey(nameof(AccountId))]
    public Account Account { get; set; }
    
}