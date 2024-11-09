using Microsoft.EntityFrameworkCore;
using YadrintsevRomanKt_31_21.Models;
using YadrintsevRomanKt_31_21.Database.Configurations;

namespace YadrintsevRomanKt_31_21.Database
{
	public class TeacherDbContext : DbContext
	{

		public DbSet<Department> Departments { get; set; }
		public DbSet<Teacher> Teachers { get; set; }
		public DbSet<AcademicDegree> AcademicDegrees { get; set; }
		public DbSet<Position> Positions { get; set; }
		public DbSet<Discipline> Disciplines { get; set; }
		public DbSet<Workload> Workloads { get; set; }

		protected override void OnModelCreating(ModelBuilder modelBuilder)
		{
			modelBuilder.ApplyConfiguration(new DepartmentConfiguration());
			modelBuilder.ApplyConfiguration(new TeacherConfiguration());
			modelBuilder.ApplyConfiguration(new AcademicDegreeConfiguration());
			modelBuilder.ApplyConfiguration(new PositionConfiguration());
			modelBuilder.ApplyConfiguration(new DisciplineConfiguration());
			modelBuilder.ApplyConfiguration(new WorkloadConfiguration());
		}

		public TeacherDbContext(DbContextOptions<TeacherDbContext> options) : base(options)
		{
		}
	}
}
