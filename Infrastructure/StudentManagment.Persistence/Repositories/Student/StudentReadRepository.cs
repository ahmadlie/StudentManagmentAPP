using Microsoft.EntityFrameworkCore;
using StudentManagment.Application.Interfaces.Repositories.Student;
using StudentManagment.Persistence.Context;
using System.Linq.Expressions;

namespace StudentManagment.Persistence.Repositories.Student;
public class StudentReadRepository : ReadRepository<Domain.Entities.Student>, IStudentReadRepository
{
    public StudentReadRepository(AppDbContext dbContext) : base(dbContext) { }

    public async override Task<IList<Domain.Entities.Student>> GetAllAsync(Expression<Func<Domain.Entities.Student, bool>>? expression = null, bool enableTracking = false)
    {
        IQueryable<Domain.Entities.Student> queryableEntity = _entity;
        if (!enableTracking) queryableEntity = queryableEntity.AsNoTracking();
        if (expression is not null) return await queryableEntity
                                   .Where(expression)
                                   .ToListAsync();
        return await queryableEntity.Include(s => s.Teachers).ToListAsync();
    }
}
