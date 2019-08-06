using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace Coding_Challenge.Models.ProjectViewModels
{
    public class cls_AddProjectViewModel
    {
        private int _iId, _iCredits;
        private DateTime _dtStartDate, _dtEndData;

        
        public int iId { get => _iId; set => _iId = value; }
        [Required]
        [Display(Name = "Credits")]
        public int iCredits { get => _iCredits; set => _iCredits = value; }
        [Required]
        [DataType(DataType.Date)]
        [Display(Name = "Start Date")]
        public DateTime dtStartDate { get => _dtStartDate; set => _dtStartDate = value; }
        [Required]
        [DataType(DataType.Date)]
        [Display(Name = "End Date")]
        public DateTime dtEndData { get => _dtEndData; set => _dtEndData = value; }
    }
}