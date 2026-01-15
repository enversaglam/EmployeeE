using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace EmployeeE.Models;

[Keyless]
public partial class EmpVu
{
    [Column("empno")]
    public int Empno { get; set; }

    [Column("EMPLOYEE")]
    [StringLength(50)]
    public string? Employee { get; set; }

    [Column("deptno")]
    public int Deptno { get; set; }
}
