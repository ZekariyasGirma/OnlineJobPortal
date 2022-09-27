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
        public int Id { get; set; }
        [Required]
        public string City { get; set; }
    }
}
