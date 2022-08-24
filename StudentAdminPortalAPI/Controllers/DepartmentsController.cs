﻿using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using StudentAdminPortalAPI.Model;
using StudentAdminPortalAPI.Repository;
using System;
using System.Threading.Tasks;

namespace StudentAdminPortalAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DepartmentsController : ControllerBase
    {
        private readonly IDepartmentRepository _departmentRepository;

        public DepartmentsController(IDepartmentRepository departmentRepository)
        {
            _departmentRepository = departmentRepository;
        }

        [HttpGet("[action]")]
        public async Task<IActionResult> GetListDepartment()
        {
            return Ok(await _departmentRepository.GetAllDepartmentAsync());
        }

        [HttpPost("[action]")]
        public async Task<IActionResult> addDepartment([FromBody] Department d)
        {

            try
            {
                var newDepartment = await _departmentRepository.InsertDepartment(d);
                if (newDepartment != null)
                {
                    return Ok(newDepartment);
                }
            }
            catch (Exception)
            {

                throw;
            }

            return NotFound();
        }

        [HttpGet("[action]/{id}")]
        
        public async Task<IActionResult> getDepartment(int id)
        {
            return Ok(await _departmentRepository.GetDepartment(id));
        }

        [HttpPut("[action]/{id}")]
        
        public async Task<IActionResult> updateDepartment([FromRoute] int id, [FromBody] Department d)
        {
            try
            {
                if (await _departmentRepository.Exists(id))
                {
                    var updateDepartment = _departmentRepository.UpdateDepartment(id, d);
                    if (updateDepartment != null)
                    {
                        return Ok(updateDepartment);
                    }
                }
            }
            catch (Exception)
            {

                throw;
            }
            return NotFound();
        }


    }
}
