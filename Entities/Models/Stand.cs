using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Entities.Models
{
    [Table("Stand")]
    public class Stand
    {
        [Required(ErrorMessage = "Stand name is required")]
        [StringLength(100, ErrorMessage = "Stand Name can't be longer than 100 characters")]
        [Key]
        public string StandName { get; set; }
        public string RentingOwner { get; set; }
        public string PhoneNumber { get; set; }
    }
}
