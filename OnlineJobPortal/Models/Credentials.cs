using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;
namespace OnlineJobPortal.Models
{
    public class Credentials
    {
        [Key]
        public long Id { get; set; }

        [Required]
        public string EducationLevelID { get; set; }

        [Required]
        public string Field { get; set; }
        
        [Required]
        [Range(0.00,4.00,ErrorMessage ="CGPA RANGE = 0.00 - 4.00")]
        public float CGPA { get; set; }

        [Required]
        public int Experience { get; set; }

        [Required]
        public string CvUrl { get; set; }

        [Display(Name ="Extra Skills")]
        public string? Skills { get; set; }
        
        [Required]
        public long JobSeekerId { get; set; }
        public virtual JobSeeker JobSeeker { get; set; }

    }
}
