﻿using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using YadrintsevRomanKt_31_21.Models;
using YadrintsevRomanKt_31_21.Database.Helpers;

namespace YadrintsevRomanKt_31_21.Database.Configurations
{
	public class DisciplineConfiguration : IEntityTypeConfiguration<Discipline>
	{
		private const string TableName = "cd_discipline";

		public void Configure(EntityTypeBuilder<Discipline> builder)
		{
			builder
				.HasKey(d => d.DisciplineId)
				.HasName($"pk_{TableName}_discipline_id");

			builder.Property(d => d.DisciplineId)
				.ValueGeneratedOnAdd()
				.HasColumnName("discipline_id")
				.HasComment("Идентификатор дисциплины");

			builder.Property(d => d.DisciplineName)
				.IsRequired()
				.HasColumnName("c_discipline_name")
				.HasColumnType(ColumnType.String).HasMaxLength(100)
				.HasComment("Название дисциплины");

			builder.Property(p => p.TeacherId)
				.HasColumnName("teacher_id")
				.IsRequired(false)
				.HasComment("Идентификатор преподавателя");

			builder.HasOne(p => p.Teacher)
				.WithMany()
				.HasForeignKey(p => p.TeacherId)
				.HasConstraintName("fk_teacher_id");

			builder.HasIndex(p => p.TeacherId, $"idx_{TableName}_fk_teacher_id");

			builder.Navigation(p => p.Teacher)
				.AutoInclude();

			builder.ToTable(TableName);
		}
	}
}
