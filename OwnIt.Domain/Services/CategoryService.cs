using OwnIt.Domain.Interfaces.Repositories;
using OwnIt.Domain.Interfaces.Services;
using OwnIt.Domain.Models;
using System.Linq.Expressions;

namespace OwnIt.Domain.Services;

public class CategoryService : ICategoryService
{
    private readonly IRepositoryWrapper _repository;

    public CategoryService(IRepositoryWrapper repository)
    {
        _repository = repository;
    }

    public async Task<Category> Delete(Category entity)
    {
        if (entity is null)
        {
            return entity;
        }

        if (await GetById(entity.Id) == default)
        {
            return null;
        }

        _repository.Category.Delete(entity);
        var commitSuccessful = await _repository.Commit();

        return !commitSuccessful ? null : entity;
    }

    public async Task<List<Category>> GetAll()
    {
        return await _repository.Category.Get();
    }

    public async Task<Category> GetById(Guid id)
    {
        return await _repository.Category.GetFirstByProperty(category => category.Id == id);
    }

    public async Task<List<Category>> GetByProperty(Expression<Func<Category, bool>> expression)
    {
        return await _repository.Category.GetAllByProperty(expression);
    }

    public async Task<Category> Post(Category entity)
    {
        if (entity is null)
        {
            return entity;
        }

        await _repository.Category.Post(entity);
        var commitSucessful = await _repository.Commit();

        return !commitSucessful ? null : entity;
    }

    public async Task<Category> Update(Category entity)
    {
        if (entity is null)
        {
            return entity;
        }

        var old = await GetById(entity.Id);

        if (old is null)
        {
            return old;
        }

        old.Name = entity.Name;
        old.Type = entity.Type;

        _repository.Category.Update(old);
        var commitSucessful = await _repository.Commit();

        return !commitSucessful ? null : entity;
    }
}
