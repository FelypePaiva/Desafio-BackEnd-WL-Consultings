using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Modelo.Domain.Modelos
{
    public class ListaTransferenciaModel
    {
        public string DestinatarioNome { get; set; }
        public string numeroContaDestinatario { get; set; }
        public decimal valorTransferencia { get; set; }
        public DateTime dataTransferencia { get; set; }
    }
}
