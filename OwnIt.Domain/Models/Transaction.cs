using OwnIt.Domain.Models.Base;

namespace OwnIt.Domain.Models;

public class Transaction : ModelBase
{
    public decimal Amount { get; set; }
    public DateTime Date { get; set; }
    public Guid Category { get; set; }
    public Guid PaymentMethod { get; set; }
}
