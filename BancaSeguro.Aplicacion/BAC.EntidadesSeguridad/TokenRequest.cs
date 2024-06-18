using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BAC.EntidadesSeguridad
{
    [Serializable]
    public class TokenRequest
    {
        public string userName { get; set; }
        public string userPassword { get; set; }
    }
}
