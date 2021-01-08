using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Collections;

namespace Entities
{
    public class Yetkili
    {
        #region KEYS
        [Key]
        [Required]
        public int YetkiliId { get; set; }
      
        public int FirmaId { get; set; }
    
        [ForeignKey("FirmaId")]
        public Firma Firma { get; set; }

        public int SubeId { get; set; }

        [ForeignKey("SubeId")]
        public Sube Sube { get; set; }
        #endregion





        [StringLength(100)]
        public string Ad { get; set; }
        
        [StringLength(100)]
        public string Soyad { get; set; }
        
        [Required]
        public Enum_Gorev Gorev { get; set; }
        
        [Required]
        [StringLength(11)]
        [DataType(DataType.PhoneNumber)]
        public string Telefon { get; set; }

        [StringLength(100)]
        [DataType(DataType.EmailAddress)]
        public string E_Posta { get; set; }
     



    }
}
