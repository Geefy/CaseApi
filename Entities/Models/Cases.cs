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

        public string CaseDescription { get; set; }
        public string ColorCode { get; set; }

        public DateTime LastUpdate{ get; set;  }

        [ForeignKey (nameof(Stand))]
        public string StandName { get; set; }
        //public virtual Stand StandNavigation { get; set; }


        public virtual ICollection<CaseHistory> CaseHistory { get; set; }
    }
}
