using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities
{
    public class VergiDairesi : IBina
    {
        [Key]
        public int DaireId { get; set; }

        public int Kod { get; set; }
        public string Ad { get; set; }
        [StringLength(50)]
        public string Il { get ; set ; }

        [StringLength(200)]
        public string Ilce { get ; set ; }
    }
}
