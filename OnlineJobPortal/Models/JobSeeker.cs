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
    [Index(nameof(Username),IsUnique =true)]
    public class JobSeeker
    {

        [Key]
        public long Id { get; set; }

        [Required, MaxLength(30)]
        [Display(Name ="First Name")]
        public string FirstName { get; set; }

        [Required, MaxLength(30)]
        [Display(Name = "Last Name")]
        public string LastName { get; set; }
        
        [Required]
        [Display(Name = "Date of Birth")]
        [DataType(DataType.Date)]
        public DateTime DOB { get; set; }
        
        [Required]
        public char Sex { get; set; }

        [DataType(DataType.PhoneNumber, ErrorMessage = "Invalid Phone Number")]
        [RegularExpression(@"^([0-9]{10})$", ErrorMessage = "Invalid Phone Number.")]
        [Display(Name ="Phone Number")]
        public string PhoneNumber { get; set; }
        
        [Required]
        [EmailAddress]
        public string Email { get; set; }
        
        [Required]
        [DataType(DataType.ImageUrl)]
        public string ImageUrl { get; set; }
        
        [Required]
        public long RegionId { get; set; }
        
        [Required]
        public long CredentialsId { get; set; }

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
        public virtual Region Region { get; set; }
        public virtual Credentials Credentials { get; set; }
    }
}
