using OwnIt.Domain.Models.Base;

namespace OwnIt.Domain.Models;

public class PaymentMethod : ModelBase
{
    public string Name { get; set; }
    public PaymentMethodType Type { get; set; }
    public decimal Limit { get; set; }
    public int DueDay { get; set; }
}

public enum PaymentMethodType
{
    Card,
    FoodCard,
    Cash
}
