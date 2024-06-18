using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BAC.EntidadesSeguridad
{
    [Serializable]
    public class RefreshTokenResponse
    {
        public string token { get; set; }
        public long expiracion { get; set; }
        public DateTime fechaExpiracionToken { get; set; }

    }
}
