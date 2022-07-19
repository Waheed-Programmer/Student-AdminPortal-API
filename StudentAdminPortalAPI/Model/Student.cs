using System;
using System.ComponentModel.DataAnnotations;

namespace StudentAdminPortalAPI.Model
{
    public class Student
    {
        [Key]
        public int StudentId { get; set; }
        public string StudentName { get; set; }
        public string StudentEmail { get; set; }
        public string StudentContact { get; set; }
        public DateTime Date { get; set; } = DateTime.Now;
        public int GenderId { get; set; }
        public Gender Gender { get; set; }
        public int DepartmentId { get; set; }
        public Department Department { get; set; } 
        public int CountryId { get; set; }
        public Country CountryName { get; set; } 
    }
}
