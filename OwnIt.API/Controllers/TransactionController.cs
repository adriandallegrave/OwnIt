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
public class TransactionController : BaseController
{
    private readonly ITransactionAppService _transactionAppService;
    private readonly ILogger<TransactionController> _logger;

    public TransactionController(ILogger<TransactionController> logger, ITransactionAppService transactionAppService)
    {
        _transactionAppService = transactionAppService;
        _logger = logger;
    }

    [HttpGet("GetAll")]
    public async Task<ActionResult<IEnumerable<Transaction>>> GetAll()
    {
        _logger.LogWarning("Entry at GetAll - Transaction");

        var result = await _transactionAppService.GetAll();

        return ResponseGetAll(result);
    }

    [HttpGet("GetById")]
    public async Task<ActionResult<Transaction>> GetById(Guid id)
    {
        _logger.LogWarning("Entry at GetById - Transaction");

        try
        {
            var result = await _transactionAppService.GetById(id);

            return ResponseGet(result);
        }
        catch
        {
            return ResponseCatch();
        }
    }

    [HttpPost("Post")]
    public async Task<ActionResult<Transaction>> Post(TransactionDto dto)
    {
        _logger.LogWarning("Entry at Post - Transaction");

        try
        {
            var result = await _transactionAppService.Post(dto);

            return ResponsePost(result);
        }
        catch
        {
            return ResponseCatch();
        }
    }

    [HttpPut("Update")]
    public async Task<ActionResult<Transaction>> Update(Guid id, TransactionDto dto)
    {
        _logger.LogWarning("Entry at Update - Transaction");

        try
        {
            if (!await _transactionAppService.Exists(id))
            {
                return ResponseIdNotFound();
            }

            var result = await _transactionAppService.Update(id, dto);

            return ResponseUpdate(result);
        }
        catch
        {
            return ResponseCatch();
        }
    }

    [HttpDelete("Delete")]
    public async Task<ActionResult<Transaction>> Delete(Guid id)
    {
        _logger.LogWarning("Entry at Delete - Transaction");

        try
        {
            if (!await _transactionAppService.Exists(id))
            {
                return ResponseIdNotFound();
            }

            var result = await _transactionAppService.Delete(id);

            return ResponseDelete(result);
        }
        catch
        {
            return ResponseCatch();
        }
    }
}
