using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;
namespace OnlineJobPortal.Models
{
    public class EducationLevel
    {
        [Key]
        public long Id { get; set; }
        [Required]
        [Display(Name ="Education Level")]
        public string EducationLevelName { get; set; }
    }
}
