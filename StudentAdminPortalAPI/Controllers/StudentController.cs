using Microsoft.AspNetCore.Mvc;
using StudentAdminPortalAPI.Repository;
using StudentAdminPortalAPI.ViewModel;
using System.Threading.Tasks;

namespace StudentAdminPortalAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StudentController : ControllerBase
    {
        private readonly IStudentRepository _studentRepository;

        public StudentController(IStudentRepository studentRepository)
        {
            _studentRepository = studentRepository;
        }
        [HttpGet("[action]")]
        //[Route("GetListStudent")]
        public async Task<IActionResult> GetListStudent()
        {
            return Ok(await _studentRepository.GetAllStudentAsync());
        }

        [HttpGet("[action]/{id}")]
        //[Route("GetListStudent")]
        public async Task<IActionResult> GetStudent(int id)
        {
            return Ok(await _studentRepository.GetStudent(id)); 
        }
        
        [HttpPut("[action]/{id}")]
        //[Route("GetListStudent")]
        public async Task<IActionResult> updateStudent([FromRoute] int id, [FromBody] updateStudentViewModel student )
        {
            if (await _studentRepository.Exists(id))
            {
                var updateStudent = _studentRepository.UpdateStudent(id, student);
                if(updateStudent != null)
                {
                    return Ok(updateStudent);
                }
            }
            return NotFound();
        }

        [HttpDelete("[action]/{id}")]
       
        public async Task<IActionResult> deleteStudent([FromRoute] int id)
        {
            if (await _studentRepository.Exists(id))
            {
                var delStudent = _studentRepository.DeleteStudentAsync(id);
                if (delStudent != null)
                {
                    return Ok(delStudent);
                }
            }
            return NotFound();
        }

        [HttpPost("[action]")]
       
        public async Task<IActionResult> addStudent([FromBody] updateStudentViewModel student)
        {

            var newStudent = await _studentRepository.InsertStudent(student);
            if (newStudent != null)
            {
                return Ok(newStudent);
            }

            return NotFound();
        }
    }
}
