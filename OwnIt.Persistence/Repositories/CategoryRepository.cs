using OwnIt.Domain.Interfaces.Repositories;
using OwnIt.Domain.Models;
using OwnIt.Persistence.Repositories.Base;

namespace OwnIt.Persistence.Repositories;

public class CategoryRepository : BaseRepository<Category>, ICategoryRepository
{
    public CategoryRepository(OwnItContext context) : base(context)
    {
    }
}
