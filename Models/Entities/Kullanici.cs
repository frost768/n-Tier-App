using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities
{
    public class Kullanici
    {
        public int Id { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }

        public Enum_KullaniciTuru Role { get; set; } = Enum_KullaniciTuru.Operator;
    }
}
