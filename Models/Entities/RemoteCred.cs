using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities
{
    public class RemoteCred
    {
        [Key]
        [Required]
        public int RemotePK { get; set; }

        
        [Required]
        [StringLength(15)]
        public string RemoteID { get; set; }
       
        [StringLength(30)]
        public string Pass { get; set; }

        public Enum_RemoteType RemoteType { get; set; }
    }
}
