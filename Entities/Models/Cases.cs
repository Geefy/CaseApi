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
           
        }
        [Key]
        public int CaseId { get; set; }

        public string CaseDescription { get; set; }
        public string ColorCode { get; set; }

        public string LastUpdate{ get; set;  }

        [ForeignKey (nameof(Stand))]
        public string StandName { get; set; }

        public string UserName { get; set; }

    }
}
