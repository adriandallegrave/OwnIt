using OwnIt.Domain.Models;

namespace OwnIt.Application.DTOs;

public class CategoryDto
{
    public string Name { get; set; }
    public CategoryType Type { get; set; }
}
