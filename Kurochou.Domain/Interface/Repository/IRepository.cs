namespace Kurochou.Domain.Interface.Repository;

public interface IRepository<T> where T : class
{
        Task<IEnumerable<T>> GetAllAsync(CancellationToken cancellationToken);
        Task<T?> GetByIdAsync(Guid? id);
        Task<int> InsertAsync(T entity);
        Task<int> UpdateAsync(T entity);
        Task<int> DeleteAsync(object id);
}