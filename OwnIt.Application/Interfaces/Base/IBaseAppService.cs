namespace OwnIt.Application.Interfaces.Base;

public interface IBaseAppService<T, TDto> where T : class
{
    public Task<List<T>> GetAll();

    public Task<T> GetById(Guid id);

    public Task<T> Post(TDto dto);

    public Task<bool> Exists(Guid id);

    public Task<T> Update(Guid id, TDto dto);

    public Task<T> Delete(Guid id);
}
