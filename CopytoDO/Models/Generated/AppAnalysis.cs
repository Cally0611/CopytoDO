using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace CopytoDO.Models;

[Table("App_Analysis")]
public partial class AppAnalysis
{
    [Key]
    [Column("App_analyzerID")]
    public int AppAnalyzerId { get; set; }

    [Column("Shift_ID")]
    [StringLength(50)]
    [Unicode(false)]
    public string? ShiftId { get; set; }

    [Column("App_Button_Colour")]
    [StringLength(14)]
    public string AppButtonColour { get; set; } = null!;

    [Column("App_Mode")]
    [StringLength(14)]
    public string AppMode { get; set; } = null!;

    [Column("App_starttime")]
    public DateTime AppStarttime { get; set; }

    [Column("App_endtime")]
    public DateTime? AppEndtime { get; set; }

    [Column("Time_diff")]
    public int? TimeDiff { get; set; }
}
