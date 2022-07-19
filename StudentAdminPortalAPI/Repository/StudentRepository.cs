using Microsoft.EntityFrameworkCore;
using StudentAdminPortalAPI.Data;
using StudentAdminPortalAPI.Model;
using StudentAdminPortalAPI.ViewModel;
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
                .Include(nameof(Gender)).Include(nameof(Department)).ToListAsync();
        }

        public async Task<Student> GetStudent(int id)
        {
            return await _applicationDbContext.Students.Where(x=>x.StudentId==id)
                .Include(nameof(Gender)).Include(nameof(Department)).FirstOrDefaultAsync();
        }
        public async Task<List<Gender>> GetAllGenderAsync()
        {
            return await _applicationDbContext.Genders.ToListAsync();
        }

        public async Task<bool> Exists(int id)
        {
            return await _applicationDbContext.Students.AnyAsync(x=>x.StudentId ==id);
        }

        public async Task<Student> UpdateStudent(int id, updateStudentViewModel student)
        {
            var checkStudent = await _applicationDbContext.Students.Where(x => x.StudentId == id).FirstOrDefaultAsync();
            if (checkStudent != null)
            {
                checkStudent.StudentName = student.StudentName;
                checkStudent.StudentEmail = student.StudentEmail;
                checkStudent.StudentContact = student.StudentContact; 
            }
            var Gender = await _applicationDbContext.Genders.Where(x => x.GenderId == student.GenderId).FirstOrDefaultAsync();
            if (Gender != null)
            {
                checkStudent.Gender.GenderName = student.GenderName;            
            }
            //var department = await _applicationDbContext.Address.Where(x => x.AddressId == student.AddressId).FirstOrDefaultAsync();
            //if (Address != null)
            //{
            //    checkStudent.Address.PhysicalAddress = student.PhysicalAddress;
            //    checkStudent.Address.PostalAddress = student.PostalAddress;
            //}
            await _applicationDbContext.SaveChangesAsync();
              return checkStudent;

        }

        public async Task<Student> DeleteStudentAsync(int id)
        {
            var student = await GetStudent(id);
            if (student != null)
            {
                 _applicationDbContext.Students.Remove(student);
                await _applicationDbContext.SaveChangesAsync();
                return student;
            }
            return null;
        }

        public async Task<Student> InsertStudent(updateStudentViewModel student)
        {
            Student model = new Student();
            model.StudentName = student.StudentName;
            model.StudentEmail = student.StudentEmail;
            model.StudentContact = student.StudentContact;
            model.GenderId = student.GenderId;
            model.DepartmentId = student.DepartmentId;
            await _applicationDbContext.Students.AddAsync(model);
            await _applicationDbContext.SaveChangesAsync();
            return model;

        }

        public async Task<List<Department>> GetAllDepartmentAsync()
        {
            return await _applicationDbContext.Departments.ToListAsync();
        }
    }
    }

