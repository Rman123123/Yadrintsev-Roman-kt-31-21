using YadrintsevRomanKt_31_21.Filters.TeacherFilters;
using YadrintsevRomanKt_31_21.Interfaces.TeacherInterfaces;
using YadrintsevRomanKt_31_21.Models;
using Microsoft.AspNetCore.Mvc;

namespace YadrintsevRomanKt_31_21.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class TeachersController : ControllerBase
    {
        private readonly ILogger<TeachersController> _logger;
        private readonly ITeacherService _teacherService;

        public TeachersController(ILogger<TeachersController> logger, ITeacherService teacherService)
        {
            _logger = logger;
            _teacherService = teacherService;
        }

        // Получение списка преподавателей с фильтрацией по кафедре, степени и должности
        [HttpGet("GetTeachersAsync")]
        public async Task<IActionResult> GetTeachersAsync(CancellationToken cancellationToken = default)
        {
            var teachers = await _teacherService.GetTeachersAsync(cancellationToken);
            return Ok(teachers);
        }

        [HttpPost("GetTeachersByDepartmentIdAsync")]
        public async Task<IActionResult> GetTeachersByDepartmentIdAsync(TeacherDepartmentFilter filter, CancellationToken cancellationToken = default)
        {
            var teachers = await _teacherService.GetTeachersByDepartmentIdAsync(filter, cancellationToken);

            return Ok(teachers);
        }

        [HttpPost("GetTeachersByAcademicDegreeIdAsync")]
        public async Task<IActionResult> GetTeachersByAcademicDegreeIdAsync(TeacherDegreeFilter filter, CancellationToken cancellationToken = default)
        {
            var teachers = await _teacherService.GetTeachersByAcademicDegreeIdAsync(filter, cancellationToken);

            return Ok(teachers);
        }


        [HttpPost("GetTeachersByPositionIdAsync")]
        public async Task<IActionResult> GetTeachersByPositionIdAsync(TeacherPositionFilter filter, CancellationToken cancellationToken = default)
        {
            var teachers = await _teacherService.GetTeachersByPositionIdAsync(filter, cancellationToken);

            return Ok(teachers);
        }
    }
}
