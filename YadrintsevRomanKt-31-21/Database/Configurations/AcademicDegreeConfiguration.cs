﻿using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using YadrintsevRomanKt_31_21.Models;
using YadrintsevRomanKt_31_21.Database.Helpers;


namespace YadrintsevRomanKt_31_21.Database.Configurations
{
	public class AcademicDegreeConfiguration : IEntityTypeConfiguration<AcademicDegree>
	{
		private const string TableName = "cd_academic_degree";

		public void Configure(EntityTypeBuilder<AcademicDegree> builder)
		{
			builder
				.HasKey(ad => ad.AcademicDegreeId)
				.HasName($"pk_{TableName}_academic_degree_id");

			builder.Property(ad => ad.AcademicDegreeId)
				.ValueGeneratedOnAdd()
				.HasColumnName("academic_degree_id")
				.HasComment("Идентификатор учебной степени");

			builder.Property(ad => ad.AcademicDegreeName)
				.IsRequired()
				.HasColumnName("c_academic_degree_name")
				.HasColumnType(ColumnType.String).HasMaxLength(100)
				.HasComment("Название учебной степени");

			builder.ToTable(TableName);
		}
	}
}
