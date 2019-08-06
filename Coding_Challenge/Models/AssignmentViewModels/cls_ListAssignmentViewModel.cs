using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Coding_Challenge.Models.AssignmentViewModels
{
    public class cls_ListAssignmentViewModel
    {
        private int _iId;
        private int? _iUserId, _iProjectId;
        private bool _bIsActive;
        private DateTime _dtAssignedDate;

        public int iId { get => _iId; set => _iId = value; }
        public int? iUserId { get => _iUserId; set => _iUserId = value; }
        public int? iProjectId { get => _iProjectId; set => _iProjectId = value; }
        public bool bIsActive { get => _bIsActive; set => _bIsActive = value; }
        public DateTime dtAssignedDate { get => _dtAssignedDate; set => _dtAssignedDate = value; }
    }
}