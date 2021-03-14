using System;
using System.Collections.Generic;
using System.Text;

namespace Crosscutting.Configuracoes
{
    public class AppSettings
    {
        public string WebApiUrl { get; set; }
        public string Secret { get; set; }
        public int ExpiracaoHoras { get; set; }
        public string Emissor { get; set; }
        public string ValidoEm { get; set; }
    }
}
