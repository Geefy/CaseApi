using System;
using System.Collections.Generic;
using System.Text;

namespace Entities.DataTransferObjects
{
    public class CasesDTO
    {
        public int CaseId { get; set; }
        public string StandName { get; set; }
        public int? ColorId { get; set; }
        public string CaseDescription { get; set; }
        public string UserOnCase { get; set; }
    }
}
