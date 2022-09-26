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
        [Display(Name ="Education Level")]
        public string EducationLevel { get; set; }

        [Required]
        public string Field { get; set; }
        
        [Required]
        public float CGPA { get; set; }

        [Required]
        public int Experience { get; set; }

        [Required]
        public string PdfUrl { get; set; }

        [Display(Name ="Extra Skills")]
        public string? ExtraSkills { get; set; }

    }
}
