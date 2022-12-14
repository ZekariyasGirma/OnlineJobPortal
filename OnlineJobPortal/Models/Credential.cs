using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;
namespace OnlineJobPortal.Models
{
    public class Credential
    {
        [Key]
        public long Id { get; set; }


        [Required]
        public string Field { get; set; }
        
        [Required]
        [Range(0.00,4.00,ErrorMessage ="CGPA RANGE = 0.00 - 4.00")]
        public float CGPA { get; set; }

        [Required]
        [Range(0, Int32.MaxValue, ErrorMessage = "Value should be greater than or equal to 0")]
        public int Experience { get; set; }

        public byte[] CvPdf { get; set; }

        [Display(Name ="Extra Skills")]
        public string Skills { get; set; }
       
        [Required]
        [ForeignKey("EducationLevel")]
        [Display(Name = "Education Level")]
        public long EducationLevelId { get; set; }
        public virtual EducationLevel EducationLevel { get; set; }


    }
}
