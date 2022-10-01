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
    [Index(nameof(Username), IsUnique = true)]
    public class Company
    {

        [Key]
        public long Id { get; set; }

        [Required, MaxLength(50)]
        [Display(Name = "Company Name")]
        public string CompanyName { get; set; }


        [RegularExpression(@"^([0-9]{12})$", ErrorMessage = "Invalid Phone Number.")]
        [Display(Name = "Phone Number")]
        public string PhoneNumber { get; set; }

        [Required]
        [EmailAddress]
        public string Email { get; set; }

        public byte[] Photo { get; set; }

        [Required]
        public long CityId { get; set; }


        [Required]
        [StringLength(450)]
        public string Username { get; set; }

        [Required]
        [DataType(DataType.Password)]
        public string Password { get; set; }

        [NotMapped]
        [Required]
        [DataType(DataType.Password)]
        [Compare("Password")]
        [Display(Name = "Confirm Password")]
        public string ConfirmPassword { get; set; }
        public virtual City City { get; set; }
    }
}
