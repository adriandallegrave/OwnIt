using OwnIt.Application.DTOs;
using OwnIt.Application.Interfaces;
using OwnIt.Application.Services.Base;
using OwnIt.Domain.Interfaces.Services;
using OwnIt.Domain.Models;

namespace OwnIt.Application.Services;

public class CategoryAppService : BaseAppService<Category>, ICategoryAppService
{
    private readonly ICategoryService _categoryService;

    public CategoryAppService(ICategoryService categoryService) : base(categoryService)
    {
        _categoryService = categoryService;
    }

    public async Task<Category> Post(CategoryDto dto)
    {
        var category = new Category()
        {
            Id = Guid.NewGuid(),
            Name = dto.Name,
            Type = dto.Type
        };

        return await _categoryService.Post(category);
    }

    public async Task<Category> Update(Guid id, CategoryDto dto)
    {
        var category = await GetById(id);

        if (category is null)
        {
            return category;
        }

        category.Name = dto.Name;
        category.Type = dto.Type;

        return await _categoryService.Update(category);
    }
}
