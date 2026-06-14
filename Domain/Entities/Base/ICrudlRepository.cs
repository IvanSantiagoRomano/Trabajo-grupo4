namespace Domain.Entities.Base
{
    public interface ICrudlRepository<T> where T: EntityBase
    {
        Task CreateAsync(T entity);
        Task UpdateAsync(T entity);
        Task DeleteAsync(Guid entityId);
        Task<T> GetByIdAsync(Guid id);
        Task<IEnumerable<T>> GetAllAsync();
        Task<IEnumerable<T>> GetAllDeletedAsync();
    }
}
