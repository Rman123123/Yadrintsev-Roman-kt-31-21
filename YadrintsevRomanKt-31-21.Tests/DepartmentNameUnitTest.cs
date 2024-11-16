using YadrintsevRomanKt_31_21.Models;


namespace YadrintsevRomanKt_31_21.Tests
{
    public class DepartmentNameUnitTest
    {
        [Fact]
        public void IsValidDepartmentName_ReturnsTrue()
        {
            // arrange
            var testDepartment1 = new Department { DepartmentName = "สา" };
            var testDepartment2 = new Department { DepartmentName = "IVT" };

            // act
            var result1 = testDepartment1.IsValidDepartmentName();
            var result2 = testDepartment2.IsValidDepartmentName();

            // assert
            Assert.True(result1);
            Assert.True(result2);
        }

        [Fact]
        public void IsValidDepartmentName_ReturnsFalse()
        {
            // arrange
            var testDepartment1 = new Department { DepartmentName = "KT123" };
            var testDepartment2 = new Department { DepartmentName = "HR!" };
            var testDepartment3 = new Department { DepartmentName = "HR Department" };

            // act
            var result1 = testDepartment1.IsValidDepartmentName();
            var result2 = testDepartment2.IsValidDepartmentName();
            var result3 = testDepartment3.IsValidDepartmentName();

            // assert
            Assert.False(result1);
            Assert.False(result2);
            Assert.False(result3);
        }

    }
}
