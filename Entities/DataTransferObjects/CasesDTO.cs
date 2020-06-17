using System;
using System.Collections.Generic;
using System.Text;

namespace Entities.DataTransferObjects
{
    public class CasesDTO
    {
        public int CaseId { get; set; }
        public string StandName { get; set; }
        public string ColorCode { get; set; }
        public string LastUpdate { get; set; }
        public string CaseDescription { get; set; }
    }
}
