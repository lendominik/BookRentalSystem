﻿using Core.Entities;

namespace Core.Contracts;

public interface IGenericRepository<T> where T : BaseEntity
{
    Task<T?> GetByIdAsync(int id);
    Task<IReadOnlyList<T>> ListAllAsync();
    Task<T?> GetEntityWithSpec(ISpecification<T> spec);
    Task<IReadOnlyList<T>> ListAsync(ISpecification<T> spec);
    Task<TResult?> GetEntityWithSpec<TResult>(ISpecification<T, TResult> spec);
    Task<IReadOnlyList<TResult>> ListAsync<TResult>(ISpecification<T, TResult> spec);

    void Add(T entity);
    void Update(T entity);
    bool Exists(int id);
    void Delete(T entity);
    Task<bool> SaveAllAsync();
    Task<IEnumerable<T>> GetAll();
}