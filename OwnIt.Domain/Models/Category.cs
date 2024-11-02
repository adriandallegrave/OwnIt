using OwnIt.Domain.Models.Base;

namespace OwnIt.Domain.Models;

public class Category : ModelBase
{
    public string Name { get; set; }
    public CategoryType Type { get; set; }
}

public enum CategoryType
{
    Monthly,
    Food,
    Car,
    Joy,
    Other
}
