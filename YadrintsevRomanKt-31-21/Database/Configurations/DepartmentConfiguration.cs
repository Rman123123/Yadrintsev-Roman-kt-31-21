using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using YadrintsevRomanKt_31_21.Models;
using YadrintsevRomanKt_31_21.Database.Helpers;

namespace YadrintsevRomanKt_31_21.Database.Configurations
{
	public class DepartmentConfiguration : IEntityTypeConfiguration<Department>
	{
		private const string TableName = "cd_department";

		public void Configure(EntityTypeBuilder<Department> builder)
		{
			builder
				.HasKey(d => d.DepartmentId)
				.HasName($"pk_{TableName}_department_id");

			builder.Property(d => d.DepartmentId)
				.ValueGeneratedOnAdd()
				.HasColumnName("department_id")
				.HasComment("Идентификатор кафедры");

			builder.Property(d => d.DepartmentName)
				.IsRequired()
				.HasColumnName("c_department_name")
				.HasColumnType(ColumnType.String).HasMaxLength(100)
				.HasComment("Название кафедры");
           
			builder.Property(d => d.HeadID)
                .HasColumnName("head_id")
                .IsRequired(false)
                .HasComment("Идентификатор руководителя кафедры");

            builder.HasOne(d => d.Teacher)
                .WithMany()
                .HasForeignKey(d => d.HeadID)
                .HasConstraintName($"fk_{TableName}_head_id")
                .OnDelete(DeleteBehavior.Restrict);

            builder.HasIndex(d => d.HeadID)
                .HasDatabaseName($"idx_{TableName}_fk_head_id");

            builder.ToTable(TableName);
		}
	}
}
