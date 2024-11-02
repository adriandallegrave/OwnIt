using OwnIt.Domain.Models;

namespace OwnIt.Application.DTOs;

public class PaymentMethodDto
{
    public string Name { get; set; }
    public PaymentMethodType Type { get; set; }
    public decimal Limit { get; set; }
    public int DueDate { get; set; }
}
