using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BAC.EntidadesSeguridad
{
    [Serializable]
    public class TokenResponse
    {
        public string responseCode { set; get; }
        public string responseMessage { set; get; }
        public string authentication { set; get; }
        public long expires { set; get; }
    }
}
