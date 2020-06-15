using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Entities.DataTransferObjects
{
   public class CasesForCreationDTO
    {
        [Required(ErrorMessage ="Stand Name is required")]
        public string StandName { get; set; }
        [Required(ErrorMessage ="Color Code required")]
        public string ColorCode { get; set; }
        [Required(ErrorMessage ="Case needs a description")]
        public string CaseDescription { get; set; }
        public string UserOnCase { get; set; }
    }
}
