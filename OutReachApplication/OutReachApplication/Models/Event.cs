using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace OutReachApplication.Models
{
    public class Event
    {
        [Key]
        [DatabaseGeneratedAttribute(DatabaseGeneratedOption.Identity)]
        [Display(Name = "Event Id")]
        public int EventId { get; set; }


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
        [DisplayFormat(DataFormatString = "{0:YYYY-MM-DD}", ApplyFormatInEditMode = true)]
        public System.DateTime Date { get; set; }

        [Display(Name = "Contact Number")]
        [Required(AllowEmptyStrings = false, ErrorMessage = "*Contact Number Required")]
        [MinLength(10)]
        [MaxLength(10)]
        public string ContactNumber { get; set; }
    }
}