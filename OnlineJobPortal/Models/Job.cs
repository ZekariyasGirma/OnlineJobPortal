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
    
    public class Job
    {
        [Key]
        public long JobId { get; set; } 
        
        [Required]
        [Display(Name ="Job Title")]
        public string JobTitle { get; set; }
        
        [Required]
        [Display(Name = "Job Description")]
        public string JobDescription { get; set; }
        public DateTime PostedDate { get; set; } = DateTime.Now;

        [Required]
        [Range(1, Int32.MaxValue, ErrorMessage = "Value should be greater than to 1")]
        public int Vaccancy { get; set; }
        
        [Required]
        public string JobType { get; set; }

        [Required]
        [Range(1, double.MaxValue, ErrorMessage = "Value should be greater than to 1")]
        public decimal Salary { get; set; }
        
        [Display(Name ="Work Hour Start")]
        [Range(0, 23, ErrorMessage = "Value should be Between 0 and 23")]
        public int? WorkHourStart { get; set; }
        
        [Display(Name = "Work Hour End")]
        [Range(0, 23, ErrorMessage = "Value should be Between 1 and 12")]
        public int? WorkHourEnd { get; set; }

        [Required]
        [Display(Name ="Education Level")]
        [Range(1,5)]
        public long EducationLevelId { get; set; }

        [Required]
        public string Field { get; set; }

        [Required]
        [Range(0.00, 4.00, ErrorMessage = "CGPA RANGE = 0.00 - 4.00")]
        public float CGPA { get; set; }

        [Required]
        [Range(0, Int32.MaxValue, ErrorMessage = "Value should be greater than or equal to 0")]
        public int Experience { get; set; }
        
        [Required]
        public long CityId { get; set; }

        [Required]
        public long CompanyId { get; set; }
        public virtual City City { get; set; }
        public virtual Company Company { get; set; }
        public virtual EducationLevel EducationLevel { get; set; }
    }
}
