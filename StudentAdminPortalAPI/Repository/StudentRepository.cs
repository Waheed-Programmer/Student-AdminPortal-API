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

        public async Task<bool> Exists(int id)
        {
            return await _applicationDbContext.Students.AnyAsync(x=>x.StudentId ==id);
        }

        public async Task<Student> UpdateStudent(int id, Student student)
        {
            var checkStudent = await _applicationDbContext.Students.Where(x => x.StudentId == id).FirstOrDefaultAsync();
            if (checkStudent != null)
            {
                checkStudent.StudentName = student.StudentName;
                checkStudent.StudentEmail = student.StudentEmail;
                checkStudent.StudentContact = student.StudentContact;
                checkStudent.GenderId = student.GenderId;
                checkStudent.Address.PhysicalAddress = student.Address.PhysicalAddress;
                checkStudent.Address.PostalAddress = student.Address.PostalAddress;

                await _applicationDbContext.SaveChangesAsync();
                return checkStudent;

            }
            return null;
        
        
        
        
        }
    }
}
