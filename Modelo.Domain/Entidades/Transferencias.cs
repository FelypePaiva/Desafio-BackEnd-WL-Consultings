using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Modelo.Domain.Entidades
{
    public class Transferencias : BaseEntity
    {
        public virtual Usuario Remetente { get; set; }
        public virtual Usuario Destinatario { get; set; }
        public decimal valorTransferencia { get; set; }
        public DateTime DataTransferencia { get; set; } = DateTime.Now;


    }
}
