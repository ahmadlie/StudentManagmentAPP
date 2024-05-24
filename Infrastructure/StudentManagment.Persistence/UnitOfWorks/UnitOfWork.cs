using StudentManagment.Application.Interfaces.Repositories;
using StudentManagment.Application.Interfaces.UnitOfWorks;
using StudentManagment.Persistence.Context;
using StudentManagment.Persistence.Repositories;

namespace StudentManagment.Persistence.UnitOfWorks;
public class UnitOfWork : IUnitOfWork
{
    private readonly AppDbContext _dbContext;
    public UnitOfWork(AppDbContext dbContext)
    {
        _dbContext = dbContext;
    }
    public async ValueTask DisposeAsync() => await _dbContext.DisposeAsync();
    public int SaveChanges() => _dbContext.SaveChanges();
    public async Task<int> SaveChangesAsync() => await _dbContext.SaveChangesAsync();
    IReadRepository<T> IUnitOfWork.GetReadRepository<T>() => new ReadRepository<T>(_dbContext);
    IWriteRepository<T> IUnitOfWork.GetWriteRepository<T>() => new WriteRepository<T>(_dbContext);
}
