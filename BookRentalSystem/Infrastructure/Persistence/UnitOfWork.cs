﻿using Core.Entities;
using Core.Interfaces;
using Infrastructure.Services;
using System.Collections;

namespace Infrastructure.Persistence;

public class UnitOfWork(AppDbContext dbContext) : IUnitOfWork
{
    private readonly AppDbContext dbContext;
    private Hashtable _repositories;

    public async Task<int> Complete()
    {
        return await dbContext.SaveChangesAsync();
    }

    public void Dispose()
    {
        dbContext.Dispose();
    }

    public IGenericRepository<TEntity> Repository<TEntity>() where TEntity : BaseEntity
    {
        if (_repositories == null) _repositories = new Hashtable();

        var type = typeof(TEntity).Name;

        if (!_repositories.ContainsKey(type))
        {
            var repositoryType = typeof(GenericRepository<>);
            var repositoryInstance = Activator.CreateInstance(repositoryType.MakeGenericType(typeof(TEntity)), dbContext);

            _repositories.Add(type, repositoryInstance);
        }

        return (IGenericRepository<TEntity>)_repositories[type];
    }
}