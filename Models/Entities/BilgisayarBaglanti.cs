using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities
{
    public class BilgisayarBaglanti
    {
        #region KEYS
        [Key]
        [Required]
        public int ConnectionId { get; set; }

        public int SubeId { get; set; }
    
        [ForeignKey("SubeId")]
        public Sube Sube { get; set; }

      
        public int FirmaId { get; set; }
     
        [ForeignKey("FirmaId")]
        public Firma Firma { get; set; }
        #endregion

        
        public virtual List<Program> Programs { get; set; }


        public virtual List<RemoteCred> RemoteCreds { get; set; }

        
        [StringLength(200)]
        public string Aciklama { get; set; }
        

    }
}
