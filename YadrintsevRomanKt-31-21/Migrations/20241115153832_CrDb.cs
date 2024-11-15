using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace YadrintsevRomanKt_31_21.Migrations
{
    /// <inheritdoc />
    public partial class CrDb : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "cd_academic_degree",
                columns: table => new
                {
                    academic_degree_id = table.Column<int>(type: "integer", nullable: false, comment: "Идентификатор учебной степени")
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    c_academic_degree_name = table.Column<string>(type: "varchar", maxLength: 100, nullable: false, comment: "Название учебной степени")
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_cd_academic_degree_academic_degree_id", x => x.academic_degree_id);
                });

            migrationBuilder.CreateTable(
                name: "cd_position",
                columns: table => new
                {
                    position_id = table.Column<int>(type: "integer", nullable: false, comment: "Идентификатор должности")
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    c_position_name = table.Column<string>(type: "varchar", maxLength: 100, nullable: false, comment: "Название должности")
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_cd_position_position_id", x => x.position_id);
                });

            migrationBuilder.CreateTable(
                name: "cd_department",
                columns: table => new
                {
                    department_id = table.Column<int>(type: "integer", nullable: false, comment: "Идентификатор кафедры")
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    c_department_name = table.Column<string>(type: "varchar", maxLength: 100, nullable: false, comment: "Название кафедры"),
                    head_id = table.Column<int>(type: "integer", nullable: true, comment: "Идентификатор руководителя кафедры")
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_cd_department_department_id", x => x.department_id);
                });

            migrationBuilder.CreateTable(
                name: "cd_teacher",
                columns: table => new
                {
                    teacher_id = table.Column<int>(type: "integer", nullable: false, comment: "Идентификатор преподавателя")
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    c_teacher_firstname = table.Column<string>(type: "varchar", maxLength: 100, nullable: false, comment: "Имя преподавателя"),
                    c_teacher_lastname = table.Column<string>(type: "varchar", maxLength: 100, nullable: false, comment: "Фамилия преподавателя"),
                    c_teacher_middlename = table.Column<string>(type: "varchar", maxLength: 100, nullable: false, comment: "Отчество преподавателя"),
                    department_id = table.Column<int>(type: "int4", nullable: true, comment: "Идентификатор кафедры"),
                    position_id = table.Column<int>(type: "int4", nullable: true, comment: "Идентификатор должности"),
                    academic_degree_id = table.Column<int>(type: "int4", nullable: true, comment: "Идентификатор ученой степени"),
                    workload_id = table.Column<int>(type: "int4", nullable: true, comment: "Идентификатор нагрузки")
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_cd_teacher_teacher_id", x => x.teacher_id);
                    table.ForeignKey(
                        name: "fk_academic_degree_id",
                        column: x => x.academic_degree_id,
                        principalTable: "cd_academic_degree",
                        principalColumn: "academic_degree_id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "fk_department_id",
                        column: x => x.department_id,
                        principalTable: "cd_department",
                        principalColumn: "department_id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "fk_position_id",
                        column: x => x.position_id,
                        principalTable: "cd_position",
                        principalColumn: "position_id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "cd_discipline",
                columns: table => new
                {
                    discipline_id = table.Column<int>(type: "integer", nullable: false, comment: "Идентификатор дисциплины")
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    c_discipline_name = table.Column<string>(type: "varchar", maxLength: 100, nullable: false, comment: "Название дисциплины"),
                    teacher_id = table.Column<int>(type: "integer", nullable: true, comment: "Идентификатор преподавателя")
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_cd_discipline_discipline_id", x => x.discipline_id);
                    table.ForeignKey(
                        name: "fk_teacher_id",
                        column: x => x.teacher_id,
                        principalTable: "cd_teacher",
                        principalColumn: "teacher_id");
                });

            migrationBuilder.CreateTable(
                name: "cd_workload",
                columns: table => new
                {
                    workload_id = table.Column<int>(type: "integer", nullable: false, comment: "Идентификатор нагрузки преподавателя"),
                    c_hours = table.Column<int>(type: "int4", nullable: false, comment: "Количество часов")
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_cd_workload_workload_id", x => x.workload_id);
                    table.ForeignKey(
                        name: "fk_workload_id",
                        column: x => x.workload_id,
                        principalTable: "cd_teacher",
                        principalColumn: "teacher_id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "cd_academic_degree",
                columns: new[] { "academic_degree_id", "c_academic_degree_name" },
                values: new object[,]
                {
                    { 1, "ScienceCandidate" },
                    { 2, "ScienceDoctor" }
                });

            migrationBuilder.InsertData(
                table: "cd_department",
                columns: new[] { "department_id", "c_department_name", "head_id" },
                values: new object[,]
                {
                    { 1, "Мат", null },
                    { 2, "ИВТ", null }
                });

            migrationBuilder.InsertData(
                table: "cd_position",
                columns: new[] { "position_id", "c_position_name" },
                values: new object[,]
                {
                    { 1, "Lecturer" },
                    { 2, "HeadLecturer" },
                    { 3, "Docent" },
                    { 4, "Professor" }
                });

            migrationBuilder.InsertData(
                table: "cd_teacher",
                columns: new[] { "teacher_id", "academic_degree_id", "department_id", "c_teacher_firstname", "c_teacher_lastname", "c_teacher_middlename", "position_id", "workload_id" },
                values: new object[,]
                {
                    { 1, 1, 1, "Алексей", "Иванов", "Петрович", 1, 1 },
                    { 2, 2, 1, "Ольга", "Смирнова", "Сергеевна", 3, 2 },
                    { 3, 1, 2, "Мария", "Кузнецова", "Андреевна", 2, 1 }
                });

            migrationBuilder.InsertData(
                table: "cd_discipline",
                columns: new[] { "discipline_id", "c_discipline_name", "teacher_id" },
                values: new object[,]
                {
                    { 1, "Mathematical analysis", 1 },
                    { 2, "Programming", 3 }
                });

            migrationBuilder.InsertData(
                table: "cd_workload",
                columns: new[] { "workload_id", "c_hours" },
                values: new object[,]
                {
                    { 1, 100 },
                    { 2, 150 }
                });

            migrationBuilder.CreateIndex(
                name: "idx_cd_department_fk_head_id",
                table: "cd_department",
                column: "head_id");

            migrationBuilder.CreateIndex(
                name: "idx_cd_discipline_fk_teacher_id",
                table: "cd_discipline",
                column: "teacher_id");

            migrationBuilder.CreateIndex(
                name: "idx_cd_teacher_fk_academic_degree_id",
                table: "cd_teacher",
                column: "academic_degree_id");

            migrationBuilder.CreateIndex(
                name: "idx_cd_teacher_fk_department_id",
                table: "cd_teacher",
                column: "department_id");

            migrationBuilder.CreateIndex(
                name: "idx_cd_teacher_fk_position_id",
                table: "cd_teacher",
                column: "position_id");

            migrationBuilder.CreateIndex(
                name: "idx_cd_teacher_fk_workload_id",
                table: "cd_teacher",
                column: "workload_id");

            migrationBuilder.AddForeignKey(
                name: "fk_cd_department_head_id",
                table: "cd_department",
                column: "head_id",
                principalTable: "cd_teacher",
                principalColumn: "teacher_id",
                onDelete: ReferentialAction.Restrict);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "fk_cd_department_head_id",
                table: "cd_department");

            migrationBuilder.DropTable(
                name: "cd_discipline");

            migrationBuilder.DropTable(
                name: "cd_workload");

            migrationBuilder.DropTable(
                name: "cd_teacher");

            migrationBuilder.DropTable(
                name: "cd_academic_degree");

            migrationBuilder.DropTable(
                name: "cd_department");

            migrationBuilder.DropTable(
                name: "cd_position");
        }
    }
}
