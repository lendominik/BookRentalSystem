using Core.Entities;

namespace Core.Interfaces;

public interface IGenericRepository<T> where T : BaseEntity
{
    void Add(T entity);
    bool Exists(int id);
    Task<IEnumerable<T>> GetAll();
    Task<T?> GetByIdAsync(int id);
    Task<IReadOnlyList<T>> ListAllAsync();
    void Delete(T entity);
    Task<bool> SaveAllAsync();
    void Update(T entity);
}