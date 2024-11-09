namespace YadrintsevRomanKt_31_21.Models
{
	public class Department
	{
		public int DepartmentId { get; set; }
		public string DepartmentName { get; set; }
		public int? HeadID { get; set; }
		public Teacher Head { get; set; }
	}
}
