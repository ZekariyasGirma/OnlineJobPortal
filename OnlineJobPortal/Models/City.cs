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
    public class City
    {
        [Key]
        public long Id { get; set; }
        
        [Required]
        [Display(Name ="City Name")]
        public string CityName { get; set; }
    }
}
