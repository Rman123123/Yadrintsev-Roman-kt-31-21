using System.Text.Json.Serialization;
using System.Text.RegularExpressions;

namespace YadrintsevRomanKt_31_21.Models
{
	public class Department
	{
		public int DepartmentId { get; set; }
		public string DepartmentName { get; set; }
        public int? HeadID { get; set; }

        [JsonIgnore]

        public Teacher Teacher { get; set; }

        public bool IsValidDepartmentName()
        {
            return Regex.IsMatch(DepartmentName, @"^\p{L}+$"); //\p{L}: Любая буква (из любого языка).
        }
    }
}
