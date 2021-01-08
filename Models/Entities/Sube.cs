using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities
{
    public class Sube : IBina
    {

        #region KEYS
        [Key]
        [Required]
        public int SubeId { get; set; }
        
        public int FirmaId { get; set; }

        [ForeignKey("FirmaId")]
        public Firma Firma { get; set; }

        public virtual List<BilgisayarBaglanti> BilgisayarBaglantilari { get; set; }
        #endregion


        [Required]
        [StringLength(100)]
        public string Ad { get; set; }

        [StringLength(50)]
        public string Il { get; set; }
        [StringLength(150)]
        public string Ilce { get; set; }
        [StringLength(11)]
        public string Telefon { get; set; }


    }
}
