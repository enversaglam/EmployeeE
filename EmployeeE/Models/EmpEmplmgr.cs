using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace EmployeeE.Models;

[Keyless]
public partial class EmpEmplmgr
{
    [StringLength(50)]
    public string? Namen { get; set; }

    public int Nummer { get; set; }

    [StringLength(50)]
    public string? Managers { get; set; }

    [Column("empno")]
    public int Empno { get; set; }
}
