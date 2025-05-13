using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Modelo.Domain.Modelos.FormValidation
{
    public interface IFormValidatiion<T>
    {
        public static abstract bool ValidarDados(T item);
    }
}
