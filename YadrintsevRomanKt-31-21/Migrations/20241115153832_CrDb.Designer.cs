﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;
using YadrintsevRomanKt_31_21.Database;

#nullable disable

namespace YadrintsevRomanKt_31_21.Migrations
{
    [DbContext(typeof(TeacherDbContext))]
    [Migration("20241115153832_CrDb")]
    partial class CrDb
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.10")
                .HasAnnotation("Relational:MaxIdentifierLength", 63);

            NpgsqlModelBuilderExtensions.UseIdentityByDefaultColumns(modelBuilder);

            modelBuilder.Entity("YadrintsevRomanKt_31_21.Models.AcademicDegree", b =>
                {
                    b.Property<int>("AcademicDegreeId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .HasColumnName("academic_degree_id")
                        .HasComment("Идентификатор учебной степени");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("AcademicDegreeId"));

                    b.Property<string>("AcademicDegreeName")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("varchar")
                        .HasColumnName("c_academic_degree_name")
                        .HasComment("Название учебной степени");

                    b.HasKey("AcademicDegreeId")
                        .HasName("pk_cd_academic_degree_academic_degree_id");

                    b.ToTable("cd_academic_degree", (string)null);

                    b.HasData(
                        new
                        {
                            AcademicDegreeId = 1,
                            AcademicDegreeName = "ScienceCandidate"
                        },
                        new
                        {
                            AcademicDegreeId = 2,
                            AcademicDegreeName = "ScienceDoctor"
                        });
                });

            modelBuilder.Entity("YadrintsevRomanKt_31_21.Models.Department", b =>
                {
                    b.Property<int>("DepartmentId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .HasColumnName("department_id")
                        .HasComment("Идентификатор кафедры");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("DepartmentId"));

                    b.Property<string>("DepartmentName")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("varchar")
                        .HasColumnName("c_department_name")
                        .HasComment("Название кафедры");

                    b.Property<int?>("HeadID")
                        .HasColumnType("integer")
                        .HasColumnName("head_id")
                        .HasComment("Идентификатор руководителя кафедры");

                    b.HasKey("DepartmentId")
                        .HasName("pk_cd_department_department_id");

                    b.HasIndex("HeadID")
                        .HasDatabaseName("idx_cd_department_fk_head_id");

                    b.ToTable("cd_department", (string)null);

                    b.HasData(
                        new
                        {
                            DepartmentId = 1,
                            DepartmentName = "Мат"
                        },
                        new
                        {
                            DepartmentId = 2,
                            DepartmentName = "ИВТ"
                        });
                });

            modelBuilder.Entity("YadrintsevRomanKt_31_21.Models.Discipline", b =>
                {
                    b.Property<int>("DisciplineId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .HasColumnName("discipline_id")
                        .HasComment("Идентификатор дисциплины");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("DisciplineId"));

                    b.Property<string>("DisciplineName")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("varchar")
                        .HasColumnName("c_discipline_name")
                        .HasComment("Название дисциплины");

                    b.Property<int?>("TeacherId")
                        .HasColumnType("integer")
                        .HasColumnName("teacher_id")
                        .HasComment("Идентификатор преподавателя");

                    b.HasKey("DisciplineId")
                        .HasName("pk_cd_discipline_discipline_id");

                    b.HasIndex(new[] { "TeacherId" }, "idx_cd_discipline_fk_teacher_id");

                    b.ToTable("cd_discipline", (string)null);

                    b.HasData(
                        new
                        {
                            DisciplineId = 1,
                            DisciplineName = "Mathematical analysis",
                            TeacherId = 1
                        },
                        new
                        {
                            DisciplineId = 2,
                            DisciplineName = "Programming",
                            TeacherId = 3
                        });
                });

            modelBuilder.Entity("YadrintsevRomanKt_31_21.Models.Position", b =>
                {
                    b.Property<int>("PositionId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .HasColumnName("position_id")
                        .HasComment("Идентификатор должности");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("PositionId"));

                    b.Property<string>("PositionName")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("varchar")
                        .HasColumnName("c_position_name")
                        .HasComment("Название должности");

                    b.HasKey("PositionId")
                        .HasName("pk_cd_position_position_id");

                    b.ToTable("cd_position", (string)null);

                    b.HasData(
                        new
                        {
                            PositionId = 1,
                            PositionName = "Lecturer"
                        },
                        new
                        {
                            PositionId = 2,
                            PositionName = "HeadLecturer"
                        },
                        new
                        {
                            PositionId = 3,
                            PositionName = "Docent"
                        },
                        new
                        {
                            PositionId = 4,
                            PositionName = "Professor"
                        });
                });

            modelBuilder.Entity("YadrintsevRomanKt_31_21.Models.Teacher", b =>
                {
                    b.Property<int>("TeacherId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .HasColumnName("teacher_id")
                        .HasComment("Идентификатор преподавателя");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("TeacherId"));

                    b.Property<int?>("AcademicDegreeId")
                        .HasColumnType("int4")
                        .HasColumnName("academic_degree_id")
                        .HasComment("Идентификатор ученой степени");

                    b.Property<int?>("DepartmentId")
                        .HasColumnType("int4")
                        .HasColumnName("department_id")
                        .HasComment("Идентификатор кафедры");

                    b.Property<string>("FirstName")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("varchar")
                        .HasColumnName("c_teacher_firstname")
                        .HasComment("Имя преподавателя");

                    b.Property<string>("LastName")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("varchar")
                        .HasColumnName("c_teacher_lastname")
                        .HasComment("Фамилия преподавателя");

                    b.Property<string>("MiddleName")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("varchar")
                        .HasColumnName("c_teacher_middlename")
                        .HasComment("Отчество преподавателя");

                    b.Property<int?>("PositionId")
                        .HasColumnType("int4")
                        .HasColumnName("position_id")
                        .HasComment("Идентификатор должности");

                    b.Property<int?>("WorkloadId")
                        .HasColumnType("int4")
                        .HasColumnName("workload_id")
                        .HasComment("Идентификатор нагрузки");

                    b.HasKey("TeacherId")
                        .HasName("pk_cd_teacher_teacher_id");

                    b.HasIndex(new[] { "AcademicDegreeId" }, "idx_cd_teacher_fk_academic_degree_id");

                    b.HasIndex(new[] { "DepartmentId" }, "idx_cd_teacher_fk_department_id");

                    b.HasIndex(new[] { "PositionId" }, "idx_cd_teacher_fk_position_id");

                    b.HasIndex(new[] { "WorkloadId" }, "idx_cd_teacher_fk_workload_id");

                    b.ToTable("cd_teacher", (string)null);

                    b.HasData(
                        new
                        {
                            TeacherId = 1,
                            AcademicDegreeId = 1,
                            DepartmentId = 1,
                            FirstName = "Алексей",
                            LastName = "Иванов",
                            MiddleName = "Петрович",
                            PositionId = 1,
                            WorkloadId = 1
                        },
                        new
                        {
                            TeacherId = 2,
                            AcademicDegreeId = 2,
                            DepartmentId = 1,
                            FirstName = "Ольга",
                            LastName = "Смирнова",
                            MiddleName = "Сергеевна",
                            PositionId = 3,
                            WorkloadId = 2
                        },
                        new
                        {
                            TeacherId = 3,
                            AcademicDegreeId = 1,
                            DepartmentId = 2,
                            FirstName = "Мария",
                            LastName = "Кузнецова",
                            MiddleName = "Андреевна",
                            PositionId = 2,
                            WorkloadId = 1
                        });
                });

            modelBuilder.Entity("YadrintsevRomanKt_31_21.Models.Workload", b =>
                {
                    b.Property<int>("WorkloadId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .HasColumnName("workload_id")
                        .HasComment("Идентификатор нагрузки преподавателя");

                    b.Property<int>("Hours")
                        .HasColumnType("int4")
                        .HasColumnName("c_hours")
                        .HasComment("Количество часов");

                    b.HasKey("WorkloadId")
                        .HasName("pk_cd_workload_workload_id");

                    b.ToTable("cd_workload", (string)null);

                    b.HasData(
                        new
                        {
                            WorkloadId = 1,
                            Hours = 100
                        },
                        new
                        {
                            WorkloadId = 2,
                            Hours = 150
                        });
                });

            modelBuilder.Entity("YadrintsevRomanKt_31_21.Models.Department", b =>
                {
                    b.HasOne("YadrintsevRomanKt_31_21.Models.Teacher", "Teacher")
                        .WithMany()
                        .HasForeignKey("HeadID")
                        .OnDelete(DeleteBehavior.Restrict)
                        .HasConstraintName("fk_cd_department_head_id");

                    b.Navigation("Teacher");
                });

            modelBuilder.Entity("YadrintsevRomanKt_31_21.Models.Discipline", b =>
                {
                    b.HasOne("YadrintsevRomanKt_31_21.Models.Teacher", "Teacher")
                        .WithMany()
                        .HasForeignKey("TeacherId")
                        .HasConstraintName("fk_teacher_id");

                    b.Navigation("Teacher");
                });

            modelBuilder.Entity("YadrintsevRomanKt_31_21.Models.Teacher", b =>
                {
                    b.HasOne("YadrintsevRomanKt_31_21.Models.AcademicDegree", "AcademicDegree")
                        .WithMany()
                        .HasForeignKey("AcademicDegreeId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .HasConstraintName("fk_academic_degree_id");

                    b.HasOne("YadrintsevRomanKt_31_21.Models.Department", "Department")
                        .WithMany()
                        .HasForeignKey("DepartmentId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .HasConstraintName("fk_department_id");

                    b.HasOne("YadrintsevRomanKt_31_21.Models.Position", "Position")
                        .WithMany()
                        .HasForeignKey("PositionId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .HasConstraintName("fk_position_id");

                    b.Navigation("AcademicDegree");

                    b.Navigation("Department");

                    b.Navigation("Position");
                });

            modelBuilder.Entity("YadrintsevRomanKt_31_21.Models.Workload", b =>
                {
                    b.HasOne("YadrintsevRomanKt_31_21.Models.Teacher", null)
                        .WithOne("Workload")
                        .HasForeignKey("YadrintsevRomanKt_31_21.Models.Workload", "WorkloadId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired()
                        .HasConstraintName("fk_workload_id");
                });

            modelBuilder.Entity("YadrintsevRomanKt_31_21.Models.Teacher", b =>
                {
                    b.Navigation("Workload")
                        .IsRequired();
                });
#pragma warning restore 612, 618
        }
    }
}