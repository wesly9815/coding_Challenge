using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace Coding_Challenge.Models.ViewModels
{
    public class cls_AddUserViewModel
    {
        private int _iId;
        private string _sFirtName, _sLastName;

        public int iId { get => _iId; set => _iId = value; }
        [Required]
        [StringLength(50)]
        [Display(Name = "First Name")]
        public string sFirtName { get => _sFirtName; set => _sFirtName = value; }
        [Required]
        [StringLength(50)]
        [Display(Name = "Last Name")]
        public string sLastName { get => _sLastName; set => _sLastName = value; }
    }
}