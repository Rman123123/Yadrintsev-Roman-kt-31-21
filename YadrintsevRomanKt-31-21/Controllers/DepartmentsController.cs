using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using YadrintsevRomanKt_31_21.Interfaces.DepartmentInterfaces;
using YadrintsevRomanKt_31_21.Models;

namespace YadrintsevRomanKt_31_21.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class DepartmentsController : Controller
    {
        private readonly ILogger<DepartmentsController> _logger;
        private readonly IDepartmentService _departmentService;

        public DepartmentsController(ILogger<DepartmentsController> logger, IDepartmentService departmentService)
        {
            _logger = logger;
            _departmentService = departmentService;
        }

        [HttpGet("GetDepartments")]
        public async Task<IActionResult> GetDepartmentsAsync(CancellationToken cancellationToken = default)
        {
            try
            {
                var lecturer = await _departmentService.GetDepartmentsAsync(cancellationToken);
                return Ok(lecturer);
            }
            catch (Exception ex)
            {
                return BadRequest($"Ошибка при вызове Кафедры: {ex.Message}");
            }

        }

        [HttpPost("AddDepartment")]
        public async Task<IActionResult> AddDepartmentAsync(string departmentName, int headID, CancellationToken cancellationToken = default)
        {
            try
            {
                await _departmentService.AddDepartmentAsync(departmentName, headID, cancellationToken);
                return Ok("Кафедра успешно добавлена.");
            }
            catch (Exception ex)
            {
                return BadRequest($"Ошибка при добавлении Кафедры : {ex.Message}");
            }
        }

        [HttpPut("UpdateDepartment/{departmentId}")]
        public async Task<IActionResult> UpdateDepartmentAsync([FromRoute]int departmentId, [FromBody]string newDepartmentName, CancellationToken cancellationToken = default)
        {
            try
            {
                await _departmentService.UpdateDepartmentAsync(departmentId, newDepartmentName, cancellationToken);
                return Ok("Кафедра успешно обновлена.");
            }
            catch (Exception ex)
            {
                return BadRequest($"Ошибка при обновлении Кафедры : {ex.Message}");
            }
        }

        [HttpDelete("DeleteDepartment/{departmentId}")]
        public async Task<IActionResult> DeleteDepartmentAsync(int departmentId, CancellationToken cancellationToken = default)
        {
            try
            {
                await _departmentService.DeleteDepartmentAsync(departmentId, cancellationToken);
                return Ok("Кафедра успешно удалена.");
            }
            catch (Exception ex)
            {
                return BadRequest($"Ошибка при удалении Кафедры: {ex.Message}");
            }
        }
    }
}
