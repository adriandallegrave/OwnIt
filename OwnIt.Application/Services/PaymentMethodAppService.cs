using OwnIt.Application.DTOs;
using OwnIt.Application.Interfaces;
using OwnIt.Application.Services.Base;
using OwnIt.Domain.Interfaces.Services;
using OwnIt.Domain.Models;

namespace OwnIt.Application.Services;

public class PaymentMethodAppService : BaseAppService<PaymentMethod>, IPaymentMethodAppService
{
    private readonly IPaymentMethodService _paymentMethodService;

    public PaymentMethodAppService(IPaymentMethodService paymentMethodService) : base(paymentMethodService)
    {
        _paymentMethodService = paymentMethodService;
    }

    public async Task<PaymentMethod> Post(PaymentMethodDto dto)
    {
        var paymentMethod = new PaymentMethod()
        {
            Id = Guid.NewGuid(),
            Name = dto.Name,
            Type = dto.Type,
            Limit = dto.Limit,
            DueDay = dto.DueDate
        };

        return await _paymentMethodService.Post(paymentMethod);
    }

    public async Task<PaymentMethod> Update(Guid id, PaymentMethodDto dto)
    {
        var paymentMethod = await GetById(id);

        if (paymentMethod is null)
        {
            return paymentMethod;
        }

        paymentMethod.Name = dto.Name;
        paymentMethod.Type = dto.Type;
        paymentMethod.Limit = dto.Limit;
        paymentMethod.DueDay = dto.DueDate;

        return await _paymentMethodService.Update(paymentMethod);
    }
}
