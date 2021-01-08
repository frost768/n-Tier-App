using System.ComponentModel.DataAnnotations;
using System.Runtime.CompilerServices;

namespace Entities
{
    public class Kategori
    {
        public int KategoriId { get; set; }

        [StringLength(100)]
        public string Ad { get; set; }
    }
}