using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using StudentAdminPortalAPI.Repository;
using System.Threading.Tasks;

namespace StudentAdminPortalAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DepartmentsController : ControllerBase
    {
        private readonly IStudentRepository _studentRepository;

        public DepartmentsController(IStudentRepository studentRepository)
        {
            _studentRepository = studentRepository;
        }

        [HttpGet("[action]")]
        public async Task<IActionResult> GetListGender()
        {
            return Ok(await _studentRepository.GetAllDepartmentAsync());
        }
    }
}
