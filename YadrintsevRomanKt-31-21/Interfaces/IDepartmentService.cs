using Microsoft.EntityFrameworkCore;
using System;
using YadrintsevRomanKt_31_21.Database;
using YadrintsevRomanKt_31_21.Models;


namespace YadrintsevRomanKt_31_21.Interfaces.DepartmentInterfaces
{
    public interface IDepartmentService
    {
        Task<Department[]> GetDepartmentsAsync(CancellationToken cancellationToken);
        Task AddDepartmentAsync(string departmentName, int headID, CancellationToken cancellationToken);
        Task UpdateDepartmentAsync(int departmentId, string newDepartmentName, CancellationToken cancellationToken);
        Task DeleteDepartmentAsync(int departmentId, CancellationToken cancellationToken);
    }

    public class DepartmentService : IDepartmentService
    {
        private readonly TeacherDbContext _dbContext;

        public DepartmentService(TeacherDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<Department[]> GetDepartmentsAsync(CancellationToken cancellationToken)
        {
            return await _dbContext.Departments.Include(d => d.Teacher).ToArrayAsync(cancellationToken);
        }

        public async Task AddDepartmentAsync(string departmentName, int headID, CancellationToken cancellationToken)
        {
            var newDepartment = new Department
            {
                DepartmentName = departmentName,
                HeadID = headID
            };

            await _dbContext.Departments.AddAsync(newDepartment, cancellationToken);
            await _dbContext.SaveChangesAsync();
        }

        public async Task UpdateDepartmentAsync(int departmentId, string newDepartmentName, CancellationToken cancellationToken)
        {
            var department = await _dbContext.Departments.FirstOrDefaultAsync(d => d.DepartmentId == departmentId, cancellationToken);
            if (department == null)
                throw new Exception("Кафедра не найдена.");

            department.DepartmentName = newDepartmentName;
            await _dbContext.SaveChangesAsync();
        }

        public async Task DeleteDepartmentAsync(int departmentId, CancellationToken cancellationToken)
        {
            var department = await _dbContext.Departments.FirstOrDefaultAsync(d => d.DepartmentId == departmentId, cancellationToken);
            if (department == null)
                throw new Exception("Кафедра не найдена.");

            _dbContext.Departments.Remove(department);
            await _dbContext.SaveChangesAsync();
        }
    }
}
