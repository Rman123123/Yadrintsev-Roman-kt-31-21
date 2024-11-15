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

            // Задание данных для степеней
            modelBuilder.Entity<AcademicDegree>().HasData(
                new AcademicDegree { AcademicDegreeId = 1, AcademicDegreeName = AcademicDegreeTypes.ScienceCandidate },
                new AcademicDegree { AcademicDegreeId = 2, AcademicDegreeName = AcademicDegreeTypes.ScienceDoctor }
            );
            // Задание данных для дисциплин
            modelBuilder.Entity<Discipline>().HasData(
                new Discipline { DisciplineId = 1, DisciplineName = "Mathematical analysis", TeacherId = 1 },
                new Discipline { DisciplineId = 2, DisciplineName = "Programming", TeacherId = 3 }
            );

            // Задание данных для нагрузки
            modelBuilder.Entity<Workload>().HasData(
                new Workload { WorkloadId = 1, Hours = 100 },
                new Workload { WorkloadId = 2, Hours = 150 }
            );

            // Задание данных для должностей
            modelBuilder.Entity<Position>().HasData(
                new Position { PositionId = 1, PositionName = Position.PositionNameType.Lecturer },
                new Position { PositionId = 2, PositionName = Position.PositionNameType.HeadLecturer },
                new Position { PositionId = 3, PositionName = Position.PositionNameType.Docent },
                new Position { PositionId = 4, PositionName = Position.PositionNameType.Professor }
            );

            // Задание данных для кафедр
            modelBuilder.Entity<Department>().HasData(
                new Department { DepartmentId = 1, DepartmentName = "Мат" },
                new Department { DepartmentId = 2, DepartmentName = "ИВТ" }
            );

            // Задание данных для преподавателей
            modelBuilder.Entity<Teacher>().HasData(
                new Teacher { TeacherId = 1, FirstName = "Алексей", LastName = "Иванов", MiddleName = "Петрович", DepartmentId = 1, AcademicDegreeId = 1, PositionId = 1, WorkloadId = 1 },
                new Teacher { TeacherId = 2, FirstName = "Ольга", LastName = "Смирнова", MiddleName = "Сергеевна", DepartmentId = 1, AcademicDegreeId = 2, PositionId = 3, WorkloadId = 2 },
                new Teacher { TeacherId = 3, FirstName = "Мария", LastName = "Кузнецова", MiddleName = "Андреевна", DepartmentId = 2, AcademicDegreeId = 1, PositionId = 2,  WorkloadId = 1 }
            );


            base.OnModelCreating(modelBuilder);
        }

		public TeacherDbContext(DbContextOptions<TeacherDbContext> options) : base(options)
		{
		}
	}
}
