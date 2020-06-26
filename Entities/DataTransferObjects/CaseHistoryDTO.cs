using System;
using System.Collections.Generic;
using System.Text;

namespace Entities.DataTransferObjects
{
    public class CaseHistoryDTO
    {

        public int CaseId { get; set; }
        public string Username { get; set; }
        public string CaseDescription { get; set; }
        public string StandName { get; set; }
        public string TimeCreated { get; set; }
        public string ColorCode { get; set; }
    }
}
