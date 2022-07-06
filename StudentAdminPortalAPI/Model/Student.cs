namespace StudentAdminPortalAPI.Model
{
    public class Student
    {
        public int StudentId { get; set; }
        public string StudentName { get; set; }
        public string StudentEmail { get; set; }
        public string StudentContact { get; set; }
        public string ProfileImg { get; set; }
        public int GenderId { get; set; }
        public Gender Gender { get; set; }
        public int AddressId { get; set; }
        public Address Address { get; set; } 
    }
}
