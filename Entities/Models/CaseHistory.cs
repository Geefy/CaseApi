using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Entities.Models
{
    [Table("CaseHistory")]
    public class CaseHistory
    {
        [Key]
        public int Id { get; set; }
        public string CaseDescription { get; set; }
        public int CaseId { get; set; }
        public string Username { get; set; }
        public string TimeCreated { get; set; }
        public string StandName { get; set; }
        public string ColorCode { get; set; }
    }
}
