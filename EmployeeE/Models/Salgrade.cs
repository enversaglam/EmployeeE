using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace EmployeeE.Models;

[Table("salgrade")]
public partial class Salgrade
{
    [Key]
    [Column("grade")]
    public int Grade { get; set; }

    [Column("losal")]
    public int? Losal { get; set; }

    [Column("hisal")]
    public int? Hisal { get; set; }
}
