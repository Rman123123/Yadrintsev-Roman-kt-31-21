using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using YadrintsevRomanKt_31_21.Models;
using YadrintsevRomanKt_31_21.Database.Helpers;

namespace YadrintsevRomanKt_31_21.Database.Configurations
{
	public class WorkloadConfiguration : IEntityTypeConfiguration<Workload>
	{
		private const string TableName = "cd_workload";

		public void Configure(EntityTypeBuilder<Workload> builder)
		{
			builder
				.HasKey(t => t.WorkloadId)
				.HasName($"pk_{TableName}_workload_id");

			builder.Property(t => t.WorkloadId)
				.ValueGeneratedOnAdd()
				.HasColumnName("workload_id")
				.HasComment("Идентификатор нагрузки преподавателя");

			builder.Property(t => t.Hours)
				.IsRequired()
				.HasColumnName("c_hours")
				.HasColumnType(ColumnType.Int)
				.HasComment("Количество часов");

			builder.ToTable(TableName);
		}
	}
}
