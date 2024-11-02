using OwnIt.Domain.Interfaces.Repositories;
using OwnIt.Domain.Models;
using OwnIt.Persistence.Repositories.Base;

namespace OwnIt.Persistence.Repositories;

public class PaymentMethodRepository : BaseRepository<PaymentMethod>, IPaymentMethodRepository
{
    public PaymentMethodRepository(OwnItContext context) : base(context)
    {

    }
}
