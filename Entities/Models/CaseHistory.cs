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

        [ForeignKey(nameof(Cases))]
        public int CaseId { get; set; }
        public virtual Cases Case { get; set; }

        [ForeignKey(nameof(Account))]
        public string Username { get; set; }
        public virtual Account UsernameNavigation { get; set; }
    }
}
