using Microsoft.EntityFrameworkCore.Query;
using StudentManagment.Domain.Common;
using System.Linq.Expressions;

namespace StudentManagment.Application.Interfaces.Repositories;
public interface IReadRepository<TEntity> where TEntity : class , IBaseEntity , new()
{
    Task<IList<TEntity>> GetAllAsync(Expression<Func<TEntity, bool>>? expression = null,
        bool enableTracking = true);
    Task<IList<TEntity>> GetAllByPageAsync(int currrentPage = 1, int pageSize = 3, Expression<Func<TEntity, bool>>? expression = null, bool enableTracking = true);
    Task<TEntity> GetAsync(Expression<Func<TEntity, bool>> expression, bool enableTracking = false);
}
