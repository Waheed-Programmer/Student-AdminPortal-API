using System.ComponentModel.DataAnnotations;

namespace StudentAdminPortalAPI.Model
{
    public class Department
    {
        [Key]
        public int DepartmentId { get; set; }
        public string DepartmentName { get; set; }
    }
}
