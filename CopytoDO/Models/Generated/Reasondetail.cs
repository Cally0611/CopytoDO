using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace CopytoDO.Models;

public partial class Reasondetail
{
    [Key]
    [Column("StopTimeID")]
    public int StopTimeId { get; set; }

    [Column("Stop_MReason")]
    [StringLength(50)]
    public string? StopMreason { get; set; }

    [Column("Stop_SReason")]
    [StringLength(50)]
    public string? StopSreason { get; set; }

    [Column("StopTime_Start")]
    [Precision(6)]
    public DateTime? StopTimeStart { get; set; }

    [Column("StopTime_ReasonSelect")]
    [Precision(6)]
    public DateTime? StopTimeReasonSelect { get; set; }

    [Column("WorkerID")]
    [StringLength(10)]
    public string? WorkerId { get; set; }

    [Column("WorkerIDName")]
    [StringLength(50)]
    [Unicode(false)]
    public string? WorkerIdname { get; set; }

    [Column("StopTime_End")]
    [Precision(6)]
    public DateTime? StopTimeEnd { get; set; }

    [Column("App_analyzerRef")]
    public int? AppAnalyzerRef { get; set; }

    [StringLength(50)]
    [Unicode(false)]
    public string? Remarks { get; set; }
}
