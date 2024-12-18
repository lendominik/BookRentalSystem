using Core.Entities;

namespace Core.Interfaces;

public interface IGenericRepository<T> where T : BaseEntity
{
    void Add(T entity);
    public bool Exists(int id);
    Task<T?> GetByIdAsync(int id);
    Task<T?> GetEntityWithSpec(ISpecification<T> spec);
    Task<IReadOnlyList<T>> ListAsync(ISpecification<T> spec);
    Task<IReadOnlyList<T>> ListAllAsync();
    void Delete(T entity);
    Task<bool> SaveAllAsync();
    void Update(T entity);
}