using StudentAdminPortalAPI.Model;

namespace StudentAdminPortalAPI.ViewModel
{
    public class updateStudentViewModel
    {

        public string StudentName { get; set; }
        public string StudentEmail { get; set; }
        public string StudentContact { get; set; }
        public string ProfileImg { get; set; }
        public int GenderId { get; set; }
        public string GenderName { get; set; }
        public int DepartmentId { get; set; }
        public Department Department { get; set; }
        public int CountryId { get; set; }
        public Country CountryName { get; set; }

    }
}
