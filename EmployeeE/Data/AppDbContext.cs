using System;
using System.Collections.Generic;
using EmployeeE.Models;
using Microsoft.EntityFrameworkCore;
using Pomelo.EntityFrameworkCore.MySql.Scaffolding.Internal;

namespace EmployeeE.Data;

public partial class AppDbContext : DbContext
{
    public AppDbContext()
    {
    }

    public AppDbContext(DbContextOptions<AppDbContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Dept> Depts { get; set; }

    public virtual DbSet<Emp> Emps { get; set; }

    public virtual DbSet<EmpEmplmgr> EmpEmplmgrs { get; set; }

    public virtual DbSet<EmpVu> EmpVus { get; set; }

    public virtual DbSet<SalaryLog> SalaryLogs { get; set; }

    public virtual DbSet<Salgrade> Salgrades { get; set; }

    public virtual DbSet<VManager> VManagers { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        => optionsBuilder.UseMySql("name=ConnectionStrings:DefaultConnection", Microsoft.EntityFrameworkCore.ServerVersion.Parse("8.0.44-mysql"));

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder
            .UseCollation("utf8mb4_0900_ai_ci")
            .HasCharSet("utf8mb4");

        modelBuilder.Entity<Dept>(entity =>
        {
            entity.HasKey(e => e.Deptno).HasName("PRIMARY");

            entity.Property(e => e.Deptno).ValueGeneratedNever();
        });

        modelBuilder.Entity<Emp>(entity =>
        {
            entity.HasKey(e => e.Empno).HasName("PRIMARY");

            entity.Property(e => e.Empno).ValueGeneratedNever();

            entity.HasOne(d => d.DeptnoNavigation).WithMany(p => p.Emps)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("emp_ibfk_1");

            entity.HasOne(d => d.MgrNavigation).WithMany(p => p.InverseMgrNavigation).HasConstraintName("emp_ibfk_2");
        });

        modelBuilder.Entity<EmpEmplmgr>(entity =>
        {
            entity.ToView("emp_emplmgr");
        });

        modelBuilder.Entity<EmpVu>(entity =>
        {
            entity.ToView("emp_vu");
        });

        modelBuilder.Entity<Salgrade>(entity =>
        {
            entity.HasKey(e => e.Grade).HasName("PRIMARY");
        });

        modelBuilder.Entity<VManager>(entity =>
        {
            entity.ToView("v_managers");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
