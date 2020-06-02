using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Entities.Models
{
    [Table("Color")]
    public class Color
    {

        public Color()
        {
            Cases = new HashSet<Cases>();
        }
        [Key]
        public string Colorid { get; set; }
        public string ColorDescription { get; set; }

        public virtual ICollection<Cases> Cases { get; set; }
    }
}
