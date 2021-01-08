using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities
{
    public class Program
    {
        [Key]
        [Required]
        public int ProgramId { get; set; }
        
        [Required]
        [StringLength(100)]
        public string Ad { get; set; }

    }
}
