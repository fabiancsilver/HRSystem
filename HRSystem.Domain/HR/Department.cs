﻿using System.ComponentModel.DataAnnotations;

namespace HRSystem.Domain.HR
{
    public class Department
    {
        [Key]
        public int DepartmentID { get; set; }


        [Required]
        [MaxLength(128)]
        public string Name { get; set; }
    }
}
