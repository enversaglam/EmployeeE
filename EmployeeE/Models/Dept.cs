using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace EmployeeE.Models;

[Table("dept")]
public partial class Dept
{
    [Key]
    [Column("deptno")]
    public int Deptno { get; set; }

    [Column("dname")]
    [StringLength(50)]
    public string? Dname { get; set; }

    [Column("loc")]
    [StringLength(50)]
    public string? Loc { get; set; }

    [InverseProperty("DeptnoNavigation")]
    public virtual ICollection<Emp> Emps { get; set; } = new List<Emp>();
}
