using StudentAdminPortalAPI.Model;
using StudentAdminPortalAPI.ViewModel;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace StudentAdminPortalAPI.Repository
{
    public interface IStudentRepository
    {
        Task<List<Student>> GetAllStudentAsync();
        Task<Student> GetStudent(int id);
        Task<List<Gender>> GetAllGenderAsync();
        Task<List<Department>> GetAllDepartmentAsync();
        Task<bool> Exists(int id);
        Task<Student> UpdateStudent(int id, updateStudentViewModel student);
        Task<Student> InsertStudent(updateStudentViewModel student);
        Task<Student> DeleteStudentAsync(int id);
    }
}
