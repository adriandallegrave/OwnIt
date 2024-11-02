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
public class CategoryController : BaseController
{
    private readonly ICategoryAppService _categoryAppService;
    private readonly ILogger<CategoryController> _logger;

    public CategoryController(ILogger<CategoryController> logger, ICategoryAppService categoryAppService)
    {
        _categoryAppService = categoryAppService;
        _logger = logger;
    }

    [HttpGet("GetAll")]
    public async Task<ActionResult<IEnumerable<Category>>> GetAll()
    {
        _logger.LogWarning("Entry at GetAll - Category");

        var result = await _categoryAppService.GetAll();

        return ResponseGetAll(result);
    }

    [HttpGet("GetById")]
    public async Task<ActionResult<Category>> GetById(Guid id)
    {
        _logger.LogWarning("Entry at GetById - Category");

        try
        {
            var result = await _categoryAppService.GetById(id);

            return ResponseGet(result);
        }
        catch
        {
            return ResponseCatch();
        }
    }

    [HttpPost("Post")]
    public async Task<ActionResult<Category>> Post(CategoryDto dto)
    {
        _logger.LogWarning("Entry at Post - Category");

        try
        {
            var result = await _categoryAppService.Post(dto);

            return ResponsePost(result);
        }
        catch
        {
            return ResponseCatch();
        }
    }

    [HttpPut("Update")]
    public async Task<ActionResult<Category>> Update(Guid id, CategoryDto dto)
    {
        _logger.LogWarning("Entry at Update - Category");

        try
        {
            if (!await _categoryAppService.Exists(id))
            {
                return ResponseIdNotFound();
            }

            var result = await _categoryAppService.Update(id, dto);

            return ResponseUpdate(result);
        }
        catch
        {
            return ResponseCatch();
        }
    }

    [HttpDelete("Delete")]
    public async Task<ActionResult<Category>> Delete(Guid id)
    {
        _logger.LogWarning("Entry at Delete - Category");

        try
        {
            if (!await _categoryAppService.Exists(id))
            {
                return ResponseIdNotFound();
            }

            var result = await _categoryAppService.Delete(id);

            return ResponseDelete(result);
        }
        catch
        {
            return ResponseCatch();
        }
    }
}
