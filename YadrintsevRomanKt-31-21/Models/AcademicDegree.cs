using System.ComponentModel.DataAnnotations;

namespace YadrintsevRomanKt_31_21.Models
{

	public class AcademicDegree
	{
        public enum AcademicDegreeTypes
        {
            [Display(Name = "Кандидат наук")]
            ScienceCandidate,

            [Display(Name = "Доктор наук")]
            ScienceDoctor,

        }
        public int AcademicDegreeId { get; set; }
		public AcademicDegreeTypes AcademicDegreeName { get; set; }
	}
}
