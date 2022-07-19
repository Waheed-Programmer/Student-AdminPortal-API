using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using StudentAdminPortalAPI.Repository;
using System.Threading.Tasks;

namespace StudentAdminPortalAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CountryController : ControllerBase
    {
        private readonly IStudentRepository _studentRepository;

        public CountryController(IStudentRepository studentRepository)
        {
            _studentRepository = studentRepository;
        }

        [HttpGet("[action]")]
        public async Task<IActionResult> GetListCountry()
        {
            return Ok(await _studentRepository.GetAllCountryAsync());
        }
    }
}
