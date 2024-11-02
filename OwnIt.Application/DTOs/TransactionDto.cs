namespace OwnIt.Application.DTOs;

public class TransactionDto
{
    public decimal Amount { get; set; }
    public DateTime Date { get; set; }
    public Guid CategoryId { get; set; }
    public Guid PaymentMethodId { get; set; }
}
