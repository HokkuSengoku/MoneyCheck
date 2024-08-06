using System.ComponentModel.DataAnnotations.Schema;

namespace MoneyCheck.Models;

public class Operation
{
    [ForeignKey(nameof(CategoryId))]
    public Category Category { get; set; }
    public int CategoryId { get; set; }
    public int OperationId { get; set; }
    public enum OperationType
    {
        Revenue,
        Expense,
        Remittanse
    }
}