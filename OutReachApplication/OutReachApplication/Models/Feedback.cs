using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace OutReachApplication.Models
{
    public class Feedback
    {
        [Key, Column(Order = 1)]
        [DatabaseGeneratedAttribute(DatabaseGeneratedOption.Identity)]
        public int PK_FeedbackId { get; set; }

        [Display(Name = "Volunteer Id")]
        [Required(AllowEmptyStrings = false, ErrorMessage = "*Volunteer Id Required")]
        public string VolunteerId { get; set; }

        [Display(Name = "First Name")]
        [Required(AllowEmptyStrings = false, ErrorMessage = "*First Name Required")]
        [RegularExpression("^[A-Za-z]*$", ErrorMessage = "*Invalid First Name")]
        public string FirstName { get; set; }

        [Display(Name = "Last Name")]
        [Required(AllowEmptyStrings = false, ErrorMessage = "*Last Name Required")]
        [RegularExpression("^[A-Za-z]*$", ErrorMessage = "*Invalid Last Name")]
        public string LastName { get; set; }

        [Display(Name = "1.Are you satisfied with this Event?")]
        [Required(AllowEmptyStrings = false, ErrorMessage = "*This Question must Answer")]
        public string Are_you_satisfied_for_this_Event { get; set; }

        [Display(Name = "2.Have you faced any difficulties in this Event?")]
        [Required(AllowEmptyStrings = false, ErrorMessage = "*This Question must Answer")]
        public string Have_you_faced_any_difficulties_in_this_Event { get; set; }

        [Display(Name = "3.Do you think the duration of the event was good enough as per your expectation?")]
        [Required(AllowEmptyStrings = false, ErrorMessage = "*This Question must Answer")]
        public string Do_you_think_the_duration_of_the_event_was_good_enough_as_per_your_expectation { get; set; }

        [Display(Name = "4.Did the event content and delivery meet your expectation?")]
        [Required(AllowEmptyStrings = false, ErrorMessage = "*This Question must Answer")]
        public string Did_the_event_content_and_delivery_meet_your_expectation { get; set; }

        [Display(Name = "5.Do you like to recommand this event to someone?")]
        [Required(AllowEmptyStrings = false, ErrorMessage = "*This Question must Answer")]
        public string Do_you_like_to_recommand_this_event_to_someone { get; set; }

    }
}