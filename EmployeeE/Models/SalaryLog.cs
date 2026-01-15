using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace EmployeeE.Models;

[Keyless]
[Table("salary_log")]
public partial class SalaryLog
{
    [Column("empno")]
    public int? Empno { get; set; }

    [Column("old_sal")]
    [Precision(10, 2)]
    public decimal? OldSal { get; set; }

    [Column("new_sal")]
    [Precision(10, 2)]
    public decimal? NewSal { get; set; }

    [Column("change_date", TypeName = "datetime")]
    public DateTime? ChangeDate { get; set; }
}
