using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using YadrintsevRomanKt_31_21.Models;
using YadrintsevRomanKt_31_21.Database.Helpers;

namespace YadrintsevRomanKt_31_21.Database.Configurations
{
	public class TeacherConfiguration : IEntityTypeConfiguration<Teacher>
	{
		private const string TableName = "cd_teacher";

		public void Configure(EntityTypeBuilder<Teacher> builder)
		{
			builder
				.HasKey(p => p.TeacherId)
				.HasName($"pk_{TableName}_teacher_id");

			builder.Property(p => p.TeacherId)
				.ValueGeneratedOnAdd()
				.HasColumnName("teacher_id")
				.HasComment("Идентификатор преподавателя");

			builder.Property(p => p.FirstName)
				.IsRequired()
				.HasColumnName("c_teacher_firstname")
				.HasColumnType(ColumnType.String).HasMaxLength(100)
				.HasComment("Имя преподавателя");

			builder.Property(p => p.LastName)
				.IsRequired()
				.HasColumnName("c_teacher_lastname")
				.HasColumnType(ColumnType.String).HasMaxLength(100)
				.HasComment("Фамилия преподавателя");

			builder.Property(p => p.MiddleName)
				.HasColumnName("c_teacher_middlename")
				.HasColumnType(ColumnType.String).HasMaxLength(100)
				.HasComment("Отчество преподавателя");



			builder.Property(p => p.DepartmentId)
				.HasColumnName("department_id")
				.HasColumnType(ColumnType.Int)
				.IsRequired(false)
				.HasComment("Идентификатор кафедры");

			builder.HasOne(p => p.Department)
				.WithMany()
				.HasForeignKey(p => p.DepartmentId)
				.HasConstraintName("fk_department_id")
				.OnDelete(DeleteBehavior.Cascade);

			builder.HasIndex(p => p.DepartmentId, $"idx_{TableName}_fk_department_id");

			builder.Navigation(p => p.Department)
				.AutoInclude();



			builder.Property(p => p.PositionId)
				.HasColumnName("position_id")
				.HasColumnType(ColumnType.Int)
				.IsRequired(false)
				.HasComment("Идентификатор должности");

			builder.HasOne(p => p.Position)
				.WithMany()
				.HasForeignKey(p => p.PositionId)
				.HasConstraintName("fk_position_id")
				.OnDelete(DeleteBehavior.Cascade);

			builder.HasIndex(p => p.PositionId, $"idx_{TableName}_fk_position_id");

			builder.Navigation(p => p.Position)
				.AutoInclude();



			builder.Property(p => p.AcademicDegreeId)
				.HasColumnName("academic_degree_id")
				.HasColumnType(ColumnType.Int)
				.IsRequired(false)
				.HasComment("Идентификатор ученой степени");

			builder.HasOne(p => p.AcademicDegree)
				.WithMany()
				.HasForeignKey(p => p.AcademicDegreeId)
				.HasConstraintName("fk_academic_degree_id")
				.OnDelete(DeleteBehavior.Cascade);

			builder.HasIndex(p => p.AcademicDegreeId, $"idx_{TableName}_fk_academic_degree_id");

			builder.Navigation(p => p.AcademicDegree)
				.AutoInclude();




			builder.Property(p => p.WorkloadId)
				.HasColumnName("workload_id")
				.HasColumnType(ColumnType.Int)
				.IsRequired(false)
				.HasComment("Идентификатор нагрузки");

			builder.HasOne(p => p.Workload)
				.WithOne()
				.HasForeignKey<Workload>(p => p.WorkloadId)
				.HasConstraintName("fk_workload_id")
				.OnDelete(DeleteBehavior.Cascade);

			builder.HasIndex(p => p.WorkloadId, $"idx_{TableName}_fk_workload_id");

			builder.Navigation(p => p.Workload)
				.AutoInclude();

			builder.ToTable(TableName);
		}
	}
}
