﻿using System.ComponentModel.DataAnnotations;

namespace StudentAdminPortalAPI.Model
{
    public class Gender
    {
        [Key]
        public int GenderId { get; set; }
        public string GenderName { get; set; }
        
    }
}