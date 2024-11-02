using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using OwnIt.API.Controllers.Base;
using OwnIt.Application.DTOs;
using OwnIt.Application.Interfaces;
using OwnIt.Domain.Models;

namespace OwnIt.API.Controllers;

[Route("api/[controller]")]
[ApiController]
[AllowAnonymous]
public class PaymentMethodController : BaseController
{
    private readonly IPaymentMethodAppService _paymentMethodAppService;
    private readonly ILogger<PaymentMethodController> _logger;

    public PaymentMethodController(ILogger<PaymentMethodController> logger, IPaymentMethodAppService paymentMethodAppService)
    {
        _paymentMethodAppService = paymentMethodAppService;
        _logger = logger;
    }

    [HttpGet("GetAll")]
    public async Task<ActionResult<IEnumerable<PaymentMethod>>> GetAll()
    {
        _logger.LogWarning("Entry at GetAll - PaymentMethod");

        var result = await _paymentMethodAppService.GetAll();

        return ResponseGetAll(result);
    }

    [HttpGet("GetById")]
    public async Task<ActionResult<PaymentMethod>> GetById(Guid id)
    {
        _logger.LogWarning("Entry at GetById - PaymentMethod");

        try
        {
            var result = await _paymentMethodAppService.GetById(id);

            return ResponseGet(result);
        }
        catch
        {
            return ResponseCatch();
        }
    }

    [HttpPost("Post")]
    public async Task<ActionResult<PaymentMethod>> Post(PaymentMethodDto dto)
    {
        _logger.LogWarning("Entry at Post - PaymentMethod");

        try
        {
            var result = await _paymentMethodAppService.Post(dto);

            return ResponsePost(result);
        }
        catch
        {
            return ResponseCatch();
        }
    }

    [HttpPut("Update")]
    public async Task<ActionResult<PaymentMethod>> Update(Guid id, PaymentMethodDto dto)
    {
        _logger.LogWarning("Entry at Update - PaymentMethod");

        try
        {
            if (!await _paymentMethodAppService.Exists(id))
            {
                return ResponseIdNotFound();
            }

            var result = await _paymentMethodAppService.Update(id, dto);

            return ResponseUpdate(result);
        }
        catch
        {
            return ResponseCatch();
        }
    }

    [HttpDelete("Delete")]
    public async Task<ActionResult<PaymentMethod>> Delete(Guid id)
    {
        _logger.LogWarning("Entry at Delete - PaymentMethod");

        try
        {
            if (!await _paymentMethodAppService.Exists(id))
            {
                return ResponseIdNotFound();
            }

            var result = await _paymentMethodAppService.Delete(id);

            return ResponseDelete(result);
        }
        catch
        {
            return ResponseCatch();
        }
    }
}
