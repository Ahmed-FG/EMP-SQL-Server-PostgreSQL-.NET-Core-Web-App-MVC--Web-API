﻿// <auto-generated> This file has been auto generated by EF Core Power Tools. </auto-generated>
#nullable disable
using System;
using System.Collections.Generic;
using EmployeeManagement.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace EmployeeManagement.Services.EF
{
    public partial class EmployeeDBContext : DbContext
    {
        public EmployeeDBContext()
        {
        }

        public EmployeeDBContext(DbContextOptions<EmployeeDBContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Department> Department { get; set; }
        public virtual DbSet<Dependent> Dependent { get; set; }
        public virtual DbSet<Emplevel> Emplevel { get; set; }
        public virtual DbSet<Employee> Employee { get; set; }
        public virtual DbSet<Position> Position { get; set; }
        public virtual DbSet<Qualification> Qualification { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
                optionsBuilder.UseSqlServer("Data Source=.;Initial Catalog=\"Employee DB\";Integrated Security=True");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Department>(entity =>
            {
                entity.HasKey(e => e.DeptId)
                    .HasName("PK_department");

                entity.Property(e => e.DeptId).ValueGeneratedNever();

                entity.HasOne(d => d.ManagerNavigation)
                    .WithMany(p => p.Department)
                    .HasForeignKey(d => d.Manager)
                    .HasConstraintName("FK_department_employee");
            });

            modelBuilder.Entity<Dependent>(entity =>
            {
                entity.HasOne(d => d.Emp)
                    .WithMany(p => p.Dependent)
                    .HasForeignKey(d => d.EmpId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("dependent_fk");
            });

            modelBuilder.Entity<Emplevel>(entity =>
            {
                entity.HasKey(e => e.LevelNo)
                    .HasName("PK_emplevel");

                entity.Property(e => e.LevelNo).ValueGeneratedNever();
            });

            modelBuilder.Entity<Employee>(entity =>
            {
                entity.HasKey(e => e.EmpId)
                    .HasName("PK_employee");

                entity.Property(e => e.EmpId).ValueGeneratedNever();

                entity.HasOne(d => d.Dept)
                    .WithMany(p => p.Employee)
                    .HasForeignKey(d => d.DeptId)
                    .HasConstraintName("FK_employee_department");

                entity.HasOne(d => d.Position)
                    .WithMany(p => p.Employee)
                    .HasForeignKey(d => d.PositionId)
                    .HasConstraintName("FK_employee_position");

                entity.HasOne(d => d.Qual)
                    .WithMany(p => p.Employee)
                    .HasForeignKey(d => d.QualId)
                    .HasConstraintName("FK_employee_qualification");
            });

            modelBuilder.Entity<Position>(entity =>
            {
                entity.Property(e => e.PositionId).ValueGeneratedNever();
            });

            modelBuilder.Entity<Qualification>(entity =>
            {
                entity.HasKey(e => e.QualId)
                    .HasName("PK_qualification");

                entity.Property(e => e.QualId).ValueGeneratedNever();
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}