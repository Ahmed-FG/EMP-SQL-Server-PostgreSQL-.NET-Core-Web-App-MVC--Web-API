﻿// <auto-generated> This file has been auto generated by EF Core Power Tools. </auto-generated>
#nullable disable
using System;
using System.Collections.Generic;

namespace EmployeeManagement
{
    public partial class Employee
    {
        public Employee()
        {
            Department = new HashSet<Department>();
            Dependent = new HashSet<Dependent>();
        }

        public int EmpId { get; set; }
        public string EmpFname { get; set; }
        public string EmpLname { get; set; }
        public int? DeptId { get; set; }
        public int? QualId { get; set; }
        public int? PositionId { get; set; }
        public int? Supervisor { get; set; }
        public DateTime? Hiredate { get; set; }
        public int? Salary { get; set; }
        public int? Commission { get; set; }

        public virtual Department Dept { get; set; }
        public virtual Position Position { get; set; }
        public virtual Qualification Qual { get; set; }
        public virtual ICollection<Department> Department { get; set; }
        public virtual ICollection<Dependent> Dependent { get; set; }
    }
}