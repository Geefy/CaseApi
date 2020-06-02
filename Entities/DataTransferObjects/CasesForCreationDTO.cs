using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Entities.DataTransferObjects
{
   public class CasesForCreationDTO
    {
        [Required(ErrorMessage ="Stand name is required")]
        public string StandName { get; set; }
        [Required(ErrorMessage ="ColorId required")]
        public string ColorId { get; set; }
        [Required(ErrorMessage ="Case needs a description")]
        public string CaseDescription { get; set; }
        public string UserOnCase { get; set; }
    }
}
