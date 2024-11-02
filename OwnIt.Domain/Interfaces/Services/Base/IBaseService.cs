using System.Linq.Expressions;

namespace OwnIt.Domain.Interfaces.Services.Base;

public interface IBaseService<T> where T : class
{
    public Task<T> Delete(T entity);

    public Task<List<T>> GetAll();

    public Task<T> GetById(Guid id);

    public Task<List<T>> GetByProperty(Expression<Func<T, bool>> expression);

    public Task<T> Post(T entity);

    public Task<T> Update(T entity);
}
