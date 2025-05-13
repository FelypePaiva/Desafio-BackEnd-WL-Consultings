using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Modelo.Domain.Modelos
{
    public class CreateUsuario
    {
        public string Name { get; set; }

        public string numeroConta { get; set; }
        public string senha { get; set; }

        public decimal saldo { get; set; }
    }
}
