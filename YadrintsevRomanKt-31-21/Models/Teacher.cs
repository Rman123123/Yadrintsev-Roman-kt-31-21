using System.Text.Json.Serialization;

namespace YadrintsevRomanKt_31_21.Models
{
	public class Teacher
	{
		public int TeacherId { get; set; }
		public string FirstName { get; set; }
		public string LastName { get; set; }
		public string MiddleName { get; set; }
		public int? DepartmentId { get; set; }

        [JsonIgnore]
        public Department Department { get; set; }
		public int? PositionId { get; set; }

        [JsonIgnore]
        public Position Position { get; set; }
		public int? AcademicDegreeId { get; set; }

        [JsonIgnore]
        public AcademicDegree AcademicDegree { get; set; }
		public int? WorkloadId { get; set; }

        [JsonIgnore]
        public Workload Workload { get; set; }
	}
}
