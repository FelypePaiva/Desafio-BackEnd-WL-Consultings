using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Modelo.Domain.Modelos.FormValidation
{
    public class TransferenciaValidator : IFormValidatiion<TransferenciaModel>
    {
        public static bool ValidarDados(TransferenciaModel item)
        {
            if (item == null)
                throw new ArgumentNullException(nameof(item));
            if (string.IsNullOrWhiteSpace(item.numeroContaDestinatario))
                throw new ArgumentException("Número da conta do destinatário não pode ser vazio.");
            if (item.valorTransferencia <= 0)
                throw new ArgumentException("Valor da transferência deve ser maior que zero.");
            return true;
        }

    }
}
