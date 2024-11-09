using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace YadrintsevRomanKt_31_21.Migrations
{
    /// <inheritdoc />
    public partial class CreateDatabase : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "cd_academic_degree",
                columns: table => new
                {
                    academic_degree_id = table.Column<int>(type: "int", nullable: false, comment: "Идентификатор учебной степени")
                        .Annotation("SqlServer:Identity", "1, 1"),
                    c_academic_degree_name = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false, comment: "Название учебной степени")
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_cd_academic_degree_academic_degree_id", x => x.academic_degree_id);
                });

            migrationBuilder.CreateTable(
                name: "cd_position",
                columns: table => new
                {
                    position_id = table.Column<int>(type: "int", nullable: false, comment: "Идентификатор должности")
                        .Annotation("SqlServer:Identity", "1, 1"),
                    c_position_name = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false, comment: "Название должности")
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_cd_position_position_id", x => x.position_id);
                });

            migrationBuilder.CreateTable(
                name: "cd_department",
                columns: table => new
                {
                    department_id = table.Column<int>(type: "int", nullable: false, comment: "Идентификатор кафедры")
                        .Annotation("SqlServer:Identity", "1, 1"),
                    c_department_name = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false, comment: "Название кафедры"),
                    head_id = table.Column<int>(type: "int", nullable: true, comment: "Идентификатор руководителя кафедры")
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_cd_department_department_id", x => x.department_id);
                });

            migrationBuilder.CreateTable(
                name: "cd_teacher",
                columns: table => new
                {
                    teacher_id = table.Column<int>(type: "int", nullable: false, comment: "Идентификатор преподавателя")
                        .Annotation("SqlServer:Identity", "1, 1"),
                    c_teacher_firstname = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false, comment: "Имя преподавателя"),
                    c_teacher_lastname = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false, comment: "Фамилия преподавателя"),
                    c_teacher_middlename = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false, comment: "Отчество преподавателя"),
                    department_id = table.Column<int>(type: "int", nullable: true, comment: "Идентификатор кафедры"),
                    position_id = table.Column<int>(type: "int", nullable: true, comment: "Идентификатор должности"),
                    academic_degree_id = table.Column<int>(type: "int", nullable: true, comment: "Идентификатор ученой степени"),
                    workload_id = table.Column<int>(type: "int", nullable: true, comment: "Идентификатор нагрузки")
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
                    discipline_id = table.Column<int>(type: "int", nullable: false, comment: "Идентификатор дисциплины")
                        .Annotation("SqlServer:Identity", "1, 1"),
                    c_discipline_name = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false, comment: "Название дисциплины"),
                    teacher_id = table.Column<int>(type: "int", nullable: true, comment: "Идентификатор преподавателя")
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_cd_discipline_discipline_id", x => x.discipline_id);
                    table.ForeignKey(
                        name: "fk_teacher_id",
                        column: x => x.teacher_id,
                        principalTable: "cd_teacher",
                        principalColumn: "teacher_id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "cd_workload",
                columns: table => new
                {
                    workload_id = table.Column<int>(type: "int", nullable: false, comment: "Идентификатор нагрузки преподавателя"),
                    c_hours = table.Column<int>(type: "int", nullable: false, comment: "Количество часов")
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
