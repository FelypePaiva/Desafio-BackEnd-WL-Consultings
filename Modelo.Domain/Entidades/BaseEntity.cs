using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Modelo.Domain.Entidades
{
    public abstract class BaseEntity
    {
        public virtual int Id { get; set; }
    }
}
