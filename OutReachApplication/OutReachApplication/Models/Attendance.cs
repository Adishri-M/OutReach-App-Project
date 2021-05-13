using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace OutReachApplication.Models
{
    public class Attendance
    {
       
        [Key, Column(Order = 1)]
        [DatabaseGeneratedAttribute(DatabaseGeneratedOption.Identity)]
        public int PK_AttendanceId { get; set; }

        [Required(AllowEmptyStrings = false, ErrorMessage = "*Id Required")]
        [Display(Name = "Volunteer Id")]
        public string VolunteerId { get; set; }

        [Required(AllowEmptyStrings = false, ErrorMessage = "*Name Required")]
        [Display(Name = "Name")]
        [StringLength(40, MinimumLength = 4, ErrorMessage = "*First Name should be between 4 and 40 characters")]
        [RegularExpression("^[A-Za-z]*$", ErrorMessage = "*Invalid Name")]
        public string Name { get; set; }


        [Display(Name = "Event Name")]
        [Required(AllowEmptyStrings = false, ErrorMessage = "*Event Name Required")]
        public string EventName { get; set; }

        [Required(AllowEmptyStrings = false, ErrorMessage = "*Date Required")]
        [DataType(DataType.Date)]
        [Display(Name = "Date Of Event")]
        //[DisplayFormat(DataFormatString = "{0:YYYY-MM-DD}", ApplyFormatInEditMode = true)]
        public System.DateTime DOE { get; set; }


        [Display(Name = "Place")]
        [Required(AllowEmptyStrings = false, ErrorMessage = "*Place Required")]
        public string Place{ get; set; }

        [Required(AllowEmptyStrings = false, ErrorMessage = "*Status Required")]
        [Display(Name = "Attended")]
        public string Attended { get; set; }

      
    }
}