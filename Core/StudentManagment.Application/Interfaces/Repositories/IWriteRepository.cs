using StudentManagment.Domain.Common;

namespace StudentManagment.Application.Interfaces.Repositories;
public interface IWriteRepository<TEntity> where TEntity : class , IBaseEntity , new()
{
    Task AddAsync(TEntity entity);
    Task AddRangeAsync(IList<TEntity> entities);
    Task<TEntity> UpdateAsync(TEntity entity);
    Task HardDeleteAsync(TEntity entity);
}
