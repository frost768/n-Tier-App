using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace API.Options
{
    public class JWTSettings
    {
        public string Secret { get; set; }
        public TimeSpan TokenLifeTime { get; set; }
    }
}
