using StudentManagment.Application.Interfaces.Repositories;
using StudentManagment.Domain.Common;

namespace StudentManagment.Application.Interfaces.UnitOfWorks;

public interface IUnitOfWork
{
    IWriteRepository<T> GetWriteRepository<T>() where T : class, IBaseEntity, new();
    IReadRepository<T> GetReadRepository<T>() where T : class, IBaseEntity, new();
    Task<int> SaveChangesAsync();
    int SaveChanges();
}
