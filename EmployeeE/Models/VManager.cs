using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace EmployeeE.Models;

[Keyless]
public partial class VManager
{
    [Column("Manager-No")]
    public int ManagerNo { get; set; }

    [Column("Manager_Name")]
    [StringLength(50)]
    public string? ManagerName { get; set; }

    [Column("Mitarbeiter_Name")]
    [StringLength(50)]
    public string? MitarbeiterName { get; set; }

    [StringLength(50)]
    public string? Position { get; set; }
}
