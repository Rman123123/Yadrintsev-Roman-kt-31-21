using Microsoft.EntityFrameworkCore;
using YadrintsevRomanKt_31_21.Database;
using YadrintsevRomanKt_31_21.Interfaces.TeacherInterfaces;
using YadrintsevRomanKt_31_21.Models;

namespace YadrintsevRomanKt_31_21.Tests
{
    public class TeacherIntegrationTest
    {
        public readonly DbContextOptions<TeacherDbContext> _dbContextOptions;

        public TeacherIntegrationTest()
        {
            _dbContextOptions = new DbContextOptionsBuilder<TeacherDbContext>()
            .UseInMemoryDatabase(databaseName: "teachers_db")
            .Options;
        }

        [Fact]
        public async Task GetTeachersByDepartmentIdAsync_KT3121_TwoObjects()
        {
            // Arrange
            var ctx = new TeacherDbContext(_dbContextOptions);
            var teacherService = new TeacherService(ctx);
            var departments = new List<Department>
            {
                new Department
                {
                    DepartmentName = "KT",
                    HeadID = 1 
                },
                new Department
                {
                    DepartmentName = "ИВТ",
                    HeadID = 1
                }
            };
            await ctx.Set<Department>().AddRangeAsync(departments);

            await ctx.SaveChangesAsync();

            var positions = new List<Position>
            {
                new Position
                {
                    PositionName = Position.PositionNameType.Lecturer
                },
                new Position
                {
                    PositionName = Position.PositionNameType.HeadLecturer
                }
            };
            await ctx.Set<Position>().AddRangeAsync(positions);

            await ctx.SaveChangesAsync();

            var academicdegrees = new List<AcademicDegree>
            {
                new AcademicDegree
                {
                    AcademicDegreeName = AcademicDegree.AcademicDegreeTypes.ScienceCandidate
                },
                new AcademicDegree
                {
                    AcademicDegreeName = AcademicDegree.AcademicDegreeTypes.ScienceDoctor
                }
            };
            await ctx.Set<AcademicDegree>().AddRangeAsync(academicdegrees);

            await ctx.SaveChangesAsync();

            var teachers = new List<Teacher>
            {
                new Teacher
                {
                    FirstName = "pupkin1",
                    LastName = "asdf",
                    MiddleName = "zxc",
                    DepartmentId = 1,
                    PositionId = 1,
                    AcademicDegreeId = 1,
                },
                new Teacher
                {
                    FirstName = "pupkin2",
                    LastName = "asdf2",
                    MiddleName = "zxc2",
                    DepartmentId = 2,
                    PositionId = 2,
                    AcademicDegreeId = 2,
                }
            };
            await ctx.Set<Teacher>().AddRangeAsync(teachers);

            await ctx.SaveChangesAsync();

            // Act
            var filter = new Filters.TeacherFilters.TeacherDepartmentFilter
            {
                DepartmentId = 1
            };
            var teachersResult = await teacherService.GetTeachersByDepartmentIdAsync(filter, CancellationToken.None);

            // Assert
            Assert.Equal(1, teachersResult.Length);
        }
    }
}
