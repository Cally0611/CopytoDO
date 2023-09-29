using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace CopytoDO.Models;

[Table("OeeDetailsAll")]
public partial class OeeDetailsAll
{
    [Key]
    [Column("OeeID")]
    public int OeeId { get; set; }

    [Column("StopTimeLocalID")]
    public int StopTimeLocalId { get; set; }

    public int OeeMachine { get; set; }

    public DateTime StopReasonStart { get; set; }

    public DateTime StopReasonEnd { get; set; }

    public int? StopDownTime { get; set; }

    [Column("Stop_MReason")]
    [StringLength(50)]
    [Unicode(false)]
    public string StopMreason { get; set; } = null!;

    [Column("Stop_SReason")]
    [StringLength(50)]
    [Unicode(false)]
    public string StopSreason { get; set; } = null!;
}
