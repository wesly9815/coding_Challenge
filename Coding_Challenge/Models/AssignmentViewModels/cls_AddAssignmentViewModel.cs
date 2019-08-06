using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Coding_Challenge.Models.AssignmentViewModels
{
    public class cls_AddAssignmentViewModel
    {
        public int iId { get ; set ; }

        [Required]
        [Display(Name = "User ID")]
        public int? iUserId { get; set; }

        [Required]
        [Display(Name = "Project Id")]
        public int? iProjectId { get ; set ; }

        [Required]
        [Display(Name = "Is Active?")]
        public string bIsActive { get ; set ; }

        [Required]
        [DataType(DataType.Date)]
        [Display(Name = "Assigned Date")]
        public DateTime dtAssignedDate { get ; set ; }
    }
}