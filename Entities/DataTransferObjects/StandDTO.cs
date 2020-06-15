using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Entities.DataTransferObjects
{
    public class StandDTO
    {
        [Required(ErrorMessage = "Stand Name is required")]
        public string StandName { get; set; }

        public string RentingOwner { get; set; }
        public string PhoneNumber { get; set; }
    }
}

