using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities
{
    public class Urun
    {
        [Key]
        public int UrunId { get; set; }

        public int KategoriId { get; set; }
        [ForeignKey("KategoriId")]
        public Kategori Kategori { get; set; }

        [StringLength(100)]
        public string Urun_adi { get; set; }

        [StringLength(500)]
        public string Urun_aciklama { get; set; }

        public decimal Fiyat { get; set; }
        public Enum_ParaBirimi Para_birimi { get; set; }
    }
}
