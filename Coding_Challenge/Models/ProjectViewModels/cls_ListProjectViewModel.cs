using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Coding_Challenge.Models.ProjectViewModels
{
    public class cls_ListProjectViewModel
    {
        private int _iId, _iCredits;
        private DateTime _dtStartDate, _dtEndData;

        public int iId { get => _iId; set => _iId = value; }
        public int iCredits { get => _iCredits; set => _iCredits = value; }
        public DateTime dtStartDate { get => _dtStartDate; set => _dtStartDate = value; }
        public DateTime dtEndData { get => _dtEndData; set => _dtEndData = value; }
    }
}