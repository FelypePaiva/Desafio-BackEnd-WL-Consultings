using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Modelo.Domain.Modelos.FormValidation
{
    public class LoginValidator : IFormValidatiion<LoginModel>
    {
        public static bool ValidarDados(LoginModel item)
        {
            if (item == null)
                throw new ArgumentNullException(nameof(item));
            if (string.IsNullOrWhiteSpace(item.numeroConta))
                throw new ArgumentException("Número da conta não pode ser vazio.");
            if (string.IsNullOrWhiteSpace(item.senha))
                throw new ArgumentException("Favor Preencher a Senha");
            return true;
        }
    }

}
