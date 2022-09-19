﻿// <auto-generated> This file has been auto generated by EF Core Power Tools. </auto-generated>
#nullable disable
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace EmployeeManagement.Models
{
    public partial class Qualification
    {
        public Qualification()
        {
            Employee = new HashSet<Employee>();
        }

        [Key]
        public int QualId { get; set; }
        [StringLength(20)]
        [Unicode(false)]
        public string QualDesc { get; set; }

        [InverseProperty("Qual")]
        public virtual ICollection<Employee> Employee { get; set; }
    }
}