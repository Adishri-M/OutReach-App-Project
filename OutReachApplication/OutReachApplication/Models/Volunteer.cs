using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace OutReachApplication.Models
{
    public class Volunteer
    {
        [Key, Column(Order = 1)]
        [DatabaseGeneratedAttribute(DatabaseGeneratedOption.Identity)]
        public int PK_VolunteerId { get; set; }

        [Required(AllowEmptyStrings = false, ErrorMessage = "*First Name Required")]
        [Display(Name = "First Name")]
        [StringLength(25, MinimumLength = 4, ErrorMessage = "*First Name should be between 4 and 25 characters")]
        [RegularExpression("^[A-Za-z]*$", ErrorMessage = "*Invalid First Name")]
        public string FirstName { get; set; }

        [Required(AllowEmptyStrings = false, ErrorMessage = "*Last Name Required")]
        [Display(Name = "Last Name")]
        [StringLength(20, MinimumLength = 3, ErrorMessage = "*Last Name should be between 4 and 20 characters")]
        [RegularExpression("^[A-Za-z]*$", ErrorMessage = "*Invalid Last Name")]
        public string LastName { get; set; }

        [Required(AllowEmptyStrings = false, ErrorMessage = "*DOB Required")]
        [DataType(DataType.Date)]
        [Display(Name = "Date Of Birth")]
        [DisplayFormat(DataFormatString = "{0:YYYY-MM-DD}", ApplyFormatInEditMode = true)]
        //[RegularExpression(@"(((0|1)[0-9]|2[0-9]|3[0-1])\/(0[1-9]|1[0-2])\/((19|20)\d\d))$", ErrorMessage = "Invalid date format.")]
        public System.DateTime DOB { get; set; }

        [Display(Name = "Gender")]
        [Required(AllowEmptyStrings = false, ErrorMessage = "*Gender Required")]
        public string Gender { get; set; }

        [Display(Name = "Contact Number")]
        [Required(AllowEmptyStrings = false, ErrorMessage = "*Contact Number Required")]
        [MinLength(10, ErrorMessage = "*Invalid Mobile Number.")]
        [MaxLength(10, ErrorMessage = "*Invalid Mobile Number.")]
        [RegularExpression(@"^([0-9]{10})$", ErrorMessage = "Invalid Mobile Number.")]
        public string ContactNumber { get; set; }

        [Display(Name = "Volunteer Id")]
        
        public string VolunteerId { get; set; }

        [Display(Name = "Password")]
        [Required(AllowEmptyStrings = false, ErrorMessage = "*Password Required")]
        [DataType(DataType.Password)]
        [MinLength(6)]
        [RegularExpression(@"^(?=.*[a-z])(?=.*[A-Z])(?=.*\d).{8,15}$", ErrorMessage = "Password is too weak")]
        public string VolunteerPassword { get; set; }


        [Display(Name = "Confirm Password")]
        [NotMapped]
        [DataType(DataType.Password)]
        [Required(AllowEmptyStrings = false, ErrorMessage = "*Confirm Password Required")]
        [Compare("VolunteerPassword", ErrorMessage = "The password and confirmation password do not match.")]
        public string ConfirmPassword { get; set; }

        public string FullName()
        {
            return this.FirstName + " " + this.LastName;
        }
    }
}