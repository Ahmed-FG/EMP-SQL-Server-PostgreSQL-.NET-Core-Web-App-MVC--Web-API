﻿// <auto-generated> This file has been auto generated by EF Core Power Tools. </auto-generated>
#nullable disable
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace EmployeeManagement.Models
{
    public partial class Department
    {
        public Department()
        {
            Employee = new HashSet<Employee>();
        }

        [Key]
        public int DeptId { get; set; }
        [StringLength(30)]
        [Unicode(false)]
        public string DeptName { get; set; }
        [StringLength(20)]
        [Unicode(false)]
        public string DeptLocation { get; set; }
        public int? Manager { get; set; }

        [ForeignKey("Manager")]
        [InverseProperty("Department")]
        public virtual Employee ManagerNavigation { get; set; }
        [InverseProperty("Dept")]
        public virtual ICollection<Employee> Employee { get; set; }
    }
}