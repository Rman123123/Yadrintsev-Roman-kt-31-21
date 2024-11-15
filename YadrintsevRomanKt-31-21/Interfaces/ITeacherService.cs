using Microsoft.EntityFrameworkCore;
using YadrintsevRomanKt_31_21.Database;
using YadrintsevRomanKt_31_21.Models;
using YadrintsevRomanKt_31_21.Filters.TeacherFilters;
using System;

namespace YadrintsevRomanKt_31_21.Interfaces.TeacherInterfaces
{
    public interface ITeacherService
    {
        public Task<Teacher[]> GetTeachersAsync( CancellationToken cancellationToken);
        public Task<Teacher[]> GetTeachersByDepartmentIdAsync(TeacherDepartmentFilter filter, CancellationToken cancellationToken);
        public Task<Teacher[]> GetTeachersByAcademicDegreeIdAsync(TeacherDegreeFilter filter, CancellationToken cancellationToken);
        public Task<Teacher[]> GetTeachersByPositionIdAsync(TeacherPositionFilter filter, CancellationToken cancellationToken);
    }
    public class TeacherService : ITeacherService
    {
        private readonly TeacherDbContext _dbContext;

        public TeacherService(TeacherDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public Task<Teacher[]> GetTeachersAsync(CancellationToken cancellationToken = default)
        {

            return _dbContext.Set<Teacher>().ToArrayAsync(cancellationToken);
        }

        public Task<Teacher[]> GetTeachersByDepartmentIdAsync(TeacherDepartmentFilter filter, CancellationToken cancellationToken = default)
        {
            return _dbContext.Set<Teacher>()
                .Where(t => t.DepartmentId == filter.DepartmentId)
                .ToArrayAsync(cancellationToken);
        }

        public Task<Teacher[]> GetTeachersByAcademicDegreeIdAsync(TeacherDegreeFilter filter, CancellationToken cancellationToken = default)
        {
            return _dbContext.Set<Teacher>()
                .Where(t => t.AcademicDegreeId == filter.AcademicDegreeId)
                .ToArrayAsync(cancellationToken);
        }

        public Task<Teacher[]> GetTeachersByPositionIdAsync(TeacherPositionFilter filter, CancellationToken cancellationToken = default)
        {
            return _dbContext.Set<Teacher>()
                .Where(t => t.PositionId == filter.PositionId)
                .ToArrayAsync(cancellationToken);
        }
    }
}
