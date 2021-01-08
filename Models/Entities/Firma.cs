using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Entities
{
    public class Firma : IBina
    {
        [Key]
        [Required]
        public int FirmaId { get; set; }

        
        public virtual List<Sube> Subeler { get; set; }

        [StringLength(100)]
        public string Ad { get; set; }

        [Required]
        public int VD_Id { get; set; }

        [ForeignKey("VD_Id")]
        public VergiDairesi VergiDairesi { get; set; }

        [Required]
        [StringLength(10)]
        public string Vergi_no { get; set; }
        
        [StringLength(50)]
        public string Il { get; set; }
        [StringLength(150)]
        public string Ilce { get; set; }
        
        [StringLength(11)]
        public string Telefon { get; set; }
        
        [StringLength(100)]
        [DataType(DataType.EmailAddress)]
        public string E_posta { get; set; }

        public Enum_MusteriTipi Musteri_tipi { get; set; }
    }
}
