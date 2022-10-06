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

        public DateTime AppliedDate { get; set; } = DateTime.Now;

        public Nullable<bool> ApprovalStatus { get; set; } = null;
        public Nullable<bool> JS_Readtatus { get; set; } = null;
        public Nullable<bool> C_ReadStatus { get; set; } = null;

        public virtual Job Job { get; set; }
        public virtual JobSeeker JobSeeker { get; set; }
        public virtual Company Company { get; set; }


    }
}
