using Microsoft.EntityFrameworkCore;
using StudentAdminPortalAPI.Data;
using StudentAdminPortalAPI.Model;
using StudentAdminPortalAPI.ViewModel;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace StudentAdminPortalAPI.Repository
{
    public class DepartmentRepository : IDepartmentRepository
    {
        private readonly ApplicationDbContext _applicationDbContext;

        public DepartmentRepository(ApplicationDbContext applicationDbContext)
        {
            _applicationDbContext = applicationDbContext;
        }

        public async Task<bool> Exists(int id)
        {
            return await _applicationDbContext.Departments.AnyAsync(x => x.DepartmentId == id);
        }

        public async Task<List<Department>> GetAllDepartmentAsync()
        {
            return await _applicationDbContext.Departments
               .ToListAsync();
        }

        public async Task<Department> GetDepartment(int id)
        {
            return await _applicationDbContext.Departments.Where(x => x.DepartmentId == id).
                FirstOrDefaultAsync();
        }

        public async Task<Department> InsertDepartment(Department d)
        {
            Department model = new Department();
            model.DepartmentName = d.DepartmentName;

            await _applicationDbContext.Departments.AddAsync(model);
            await _applicationDbContext.SaveChangesAsync();
            return model;
        }

        public async Task<Department> UpdateDepartment(int id, Department d)
        {
            var checkDepartment = await _applicationDbContext.Departments.Where(x => x.DepartmentId == id).FirstOrDefaultAsync();
            if (checkDepartment != null)
            {
                checkDepartment.DepartmentName = d.DepartmentName;

            }

            await _applicationDbContext.SaveChangesAsync();
            return checkDepartment;
        }
    }
    
}

