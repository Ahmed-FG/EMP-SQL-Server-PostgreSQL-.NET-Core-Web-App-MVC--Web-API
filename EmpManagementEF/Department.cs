﻿// <auto-generated> This file has been auto generated by EF Core Power Tools. </auto-generated>
#nullable disable
using System;
using System.Collections.Generic;

namespace EmployeeManagement
{
    public partial class Department
    {
        public Department()
        {
            Employee = new HashSet<Employee>();
        }

        public int DeptId { get; set; }
        public string DeptName { get; set; }
        public string DeptLocation { get; set; }
        public int? Manager { get; set; }

        public virtual Employee ManagerNavigation { get; set; }
        public virtual ICollection<Employee> Employee { get; set; }
    }
}