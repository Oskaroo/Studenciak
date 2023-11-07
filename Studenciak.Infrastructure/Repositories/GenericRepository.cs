using System.Linq.Expressions;
using Domain.Repositories;
using Infrastructure.Persistence;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Repositories;

internal class GenericRepository<TEntity, TKey> : IGenericRepository<TEntity, TKey> where TEntity : class
{
    private readonly StudenciakDbContext _dbContext;
    private readonly DbSet<TEntity> _entities;

    public GenericRepository(StudenciakDbContext dbContext)
    {
        _dbContext = dbContext;
        _entities = _dbContext.Set<TEntity>();
    }
    public Task<TEntity?> GetByIdAsync(TKey id)
    {
        throw new NotImplementedException();
    }

    public Task<IEnumerable<TEntity>> GetAllAsync(Expression<Func<TEntity, object>>? include = null)
    {
        throw new NotImplementedException();
    }

    public Task<int> AddAsync(TEntity entity)
    {
        throw new NotImplementedException();
    }

    public Task UpdateAsync(TEntity entity)
    {
        throw new NotImplementedException();
    }

    public Task DeleteAsync(TEntity entity)
    {
        throw new NotImplementedException();
    }
}