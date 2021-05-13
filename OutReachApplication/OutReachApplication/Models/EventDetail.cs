using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace OutReachApplication.Models
{
    public class EventDetail
    {
        [Key]
        [Display(Name = "EventId")]
        [Required(AllowEmptyStrings = false, ErrorMessage = "*Id Required")]
        public int EventId { get; set; }

        [Display(Name = "Event Type")]
        [Required(AllowEmptyStrings = false, ErrorMessage = "*EventType Required")]
        public string EventType { get; set; }


        [Display(Name = "Activity")]
        [Required(AllowEmptyStrings = false, ErrorMessage = "*Activity Required")]
        public string Activity { get; set; }

        [Display(Name = "Description")]
        public string Description { get; set; }

        [Display(Name = "Place")]
        [Required(AllowEmptyStrings = false, ErrorMessage = "*Place Required")]
        public string Place { get; set; }


        [Required(AllowEmptyStrings = false, ErrorMessage = "*Date Required")]
        [DataType(DataType.Date)]
        [Display(Name = "Date Of Event")]
       // [DisplayFormat(DataFormatString = "{0:YYYY-MM-DD}", ApplyFormatInEditMode = true)]
        public System.DateTime Date { get; set; }

        [Display(Name = "Contact Number")]
        [Required(AllowEmptyStrings = false, ErrorMessage = "*Contact Number Required")]
        [RegularExpression(@"^([0-9]{10})$", ErrorMessage = "Invalid Mobile Number.")]
        [MinLength(10, ErrorMessage = "*Invalid Mobile Number.")]
        [MaxLength(10, ErrorMessage = "*Invalid Mobile Number.")]
        public string ContactNumber { get; set; }

        [Display(Name = "No Of Volunteers")]
        [Required(AllowEmptyStrings = false, ErrorMessage = "*No Of Volunteers")]
        public int NoOfVolunteers { get; set; }



    }
}