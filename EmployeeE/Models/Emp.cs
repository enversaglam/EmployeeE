using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace EmployeeE.Models;

[Table("emp")]
[Index("Deptno", Name = "deptno")]
[Index("Empno", Name = "idx_empno")]
[Index("Mgr", Name = "mgr")]
public partial class Emp
{
    [Key]
    [Column("empno")]
    public int Empno { get; set; }

    [Column("ename")]
    [StringLength(50)]
    public string? Ename { get; set; }

    [Column("job")]
    [StringLength(50)]
    public string? Job { get; set; }

    [Column("mgr")]
    public int? Mgr { get; set; }

    [Column("hiredate")]
    public DateOnly? Hiredate { get; set; }

    [Column("sal")]
    [Precision(10, 2)]
    public decimal Sal { get; set; }

    [Column("comm")]
    [Precision(10, 2)]
    public decimal? Comm { get; set; }

    [Column("deptno")]
    public int Deptno { get; set; }

    [ForeignKey("Deptno")]
    [InverseProperty("Emps")]
    public virtual Dept DeptnoNavigation { get; set; } = null!;

    [InverseProperty("MgrNavigation")]
    public virtual ICollection<Emp> InverseMgrNavigation { get; set; } = new List<Emp>();

    [ForeignKey("Mgr")]
    [InverseProperty("InverseMgrNavigation")]
    public virtual Emp? MgrNavigation { get; set; }
}
