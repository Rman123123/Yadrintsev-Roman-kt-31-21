using System.ComponentModel.DataAnnotations;

namespace YadrintsevRomanKt_31_21.Models
{
	public enum AcademicDegreeTypes
	{
		[Display(Name = "Кандидат наук")]
		ScienceCandidate,

		[Display(Name = "Доктор наук")]
		ScienceDoctor,

	}
	public class AcademicDegree
	{
		public int AcademicDegreeId { get; set; }
		public AcademicDegreeTypes AcademicDegreeName { get; set; }
	}
}
