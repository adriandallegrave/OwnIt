using OwnIt.Domain.Interfaces.Services.Base;

namespace OwnIt.Application.Services.Base;

public class BaseAppService<T> where T : class
{
    private IBaseService<T> _service;

    public BaseAppService(IBaseService<T> service)
    {
        _service = service;
    }

    public async Task<T> Delete(Guid id)
    {
        var entity = await GetById(id);

        if (entity is null)
        {
            return entity;
        }

        return await _service.Delete(entity);
    }

    public async Task<bool> Exists(Guid id)
    {
        return await GetById(id) != null;
    }

    public async Task<List<T>> GetAll()
    {
        return await _service.GetAll();
    }

    public async Task<T> GetById(Guid id)
    {
        return await _service.GetById(id);
    }
}
