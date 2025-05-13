using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Modelo.Domain.Modelos.FormValidation
{
    public class CreateUsuarioValidator : IFormValidatiion<CreateUsuario>
    {
        public static bool ValidarDados(CreateUsuario item)
        {
            if (item == null)
                throw new ArgumentNullException(nameof(item));
            if (string.IsNullOrWhiteSpace(item.Name))
                throw new ArgumentException("Número da conta do destinatário não pode ser vazio.");
            if (string.IsNullOrWhiteSpace(item.numeroConta))
                throw new ArgumentException("Valor da transferência deve ser maior que zero.");
            if (string.IsNullOrWhiteSpace(item.senha))
                throw new ArgumentException("Favor Preencher a Senha");
            if (item.saldo < 0)
                throw new ArgumentException("Valor da transferência deve ser maior que zero.");
            return true;
        }
    }

}
