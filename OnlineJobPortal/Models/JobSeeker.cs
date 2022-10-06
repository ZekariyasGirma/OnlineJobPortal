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
        [MinimumAge(18,ErrorMessage ="Age must be Greater than 18")]
        [Display(Name = "Date of Birth")]
        [DataType(DataType.Date)]
        public DateTime DOB { get; set; }
        
        [Required]
        public string Sex { get; set; }

        [RegularExpression(@"^([0-9]{12})$", ErrorMessage = "Invalid Phone Number.")]
        [Display(Name ="Phone Number")]
        public string PhoneNumber { get; set; }
        
        [Required]
        [EmailAddress]
        public string Email { get; set; }
        

        public byte[] Photo { get; set; }
        
        [ForeignKey("City")]
        [Required]
        public long? CityId { get; set; }

        [ForeignKey("Credential")]
        public Nullable<long> CredentialId { get; set; } = null;


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
        public virtual Credential Credential { get; set; }
    }
}
