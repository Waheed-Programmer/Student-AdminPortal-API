using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using StudentAdminPortalAPI.Model;
using StudentAdminPortalAPI.Repository;
using System;
using System.Threading.Tasks;

namespace StudentAdminPortalAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CountryController : ControllerBase
    {
        private readonly ICountryRepository _countryRepository;

        public CountryController(ICountryRepository countryRepository)
        {
            _countryRepository = countryRepository;
        }

        [HttpGet("[action]")]
        public async Task<IActionResult> getListCountry()
        {
            return Ok(await _countryRepository.GetAllCountryAsync());
        }

        [HttpPost("[action]")]
        public async Task<IActionResult> addDepartment([FromBody] Country c)
        {

            try
            {
                var newCountry = await _countryRepository.InsertCountry(c);
                if (newCountry != null)
                {
                    return Ok(newCountry);
                }
            }
            catch (Exception)
            {

                throw;
            }

            return NotFound();
        }

        [HttpGet("[action]/{id}")]

        public async Task<IActionResult> getCountry(int id)
        {
            return Ok(await _countryRepository.GetCountryById(id));
        }

    }
}
