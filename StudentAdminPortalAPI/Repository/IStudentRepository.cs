﻿using StudentAdminPortalAPI.Model;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace StudentAdminPortalAPI.Repository
{
    public interface IStudentRepository
    {
        Task<List<Student>> GetAllStudentAsync();
        Task<Student> GetStudent(int id);
        Task<List<Gender>> GetAllGenderAsync();
    }
}
