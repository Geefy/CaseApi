using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Entities.Models
{
    [Table("Cases")]
    public class Cases
    {
        public Cases()
        {
            CaseHistory = new HashSet<CaseHistory>();
        }
        [Key]
        public int CaseId { get; set; }
        public string StandName { get; set; }

        public string CaseDescription { get; set; }

        [ForeignKey (nameof(Color))]
        public string ColorId { get; set; }
        public virtual Color ColorNavigation { get; set; }

        [ForeignKey (nameof(Account))]
        public string UserOnCase { get; set; }


        public virtual ICollection<CaseHistory> CaseHistory { get; set; }
    }
}
