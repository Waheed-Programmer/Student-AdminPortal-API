using Microsoft.EntityFrameworkCore;
using StudentAdminPortalAPI.Data;
using StudentAdminPortalAPI.Model;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace StudentAdminPortalAPI.Repository
{
    public class StudentRepository : IStudentRepository
    {
        private readonly ApplicationDbContext _applicationDbContext;

        public StudentRepository(ApplicationDbContext applicationDbContext)
        {
            _applicationDbContext = applicationDbContext;
        }


        public async Task<List<Student>> GetAllStudentAsync()
        {
            return await _applicationDbContext.Students
                .Include(nameof(Gender)).Include(nameof(Address)).ToListAsync();
        }

        public async Task<Student> GetStudent(int id)
        {
            return await _applicationDbContext.Students.Where(x=>x.StudentId==id)
                .Include(nameof(Gender)).Include(nameof(Address)).FirstOrDefaultAsync();
        }
        public async Task<List<Gender>> GetAllGenderAsync()
        {
            return await _applicationDbContext.Genders.ToListAsync();
        }
    }
}
