using StudentAdminPortalAPI.Model;
using StudentAdminPortalAPI.ViewModel;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace StudentAdminPortalAPI.Repository
{
    public interface IDepartmentRepository
    {
        Task<List<Department>> GetAllDepartmentAsync();
        Task<Department> GetDepartment(int id);    
        Task<bool> Exists(int id);
        Task<Department> UpdateDepartment(int id, Department d);
        Task<Department> InsertDepartment(Department d);
        
    }
}
