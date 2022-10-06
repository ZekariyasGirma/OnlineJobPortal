using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Threading.Tasks;

namespace OnlineJobPortal.Models
{

    public class JobNotification
    {
        [Key]
        public long Id { get; set; }

        [Required]
        [ForeignKey("Job")]
        public long JobId { get; set; }

        [Required]
        [ForeignKey("JobSeeker")]
        public long JobSeekerId { get; set; }

        [Required]
        [ForeignKey("Company")]
        public long CompanyId { get; set; }

        public Nullable<DateTime> AppliedDate { get; set; } = DateTime.Now;

        public string ApprovalStatus { get; set; }
        public string JS_Readtatus { get; set; } 
        public string C_ReadStatus { get; set; } 

        public virtual Job Job { get; set; }
        public virtual JobSeeker JobSeeker { get; set; }
        public virtual Company Company { get; set; }


    }
}
