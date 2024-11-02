using OwnIt.Application.DTOs;
using OwnIt.Application.Interfaces.Base;
using OwnIt.Domain.Models;

namespace OwnIt.Application.Interfaces;

public interface IPaymentMethodAppService : IBaseAppService<PaymentMethod, PaymentMethodDto>
{
}
