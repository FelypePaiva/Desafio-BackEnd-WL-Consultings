﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Modelo.Domain.Entidades
{
    public class Usuario : BaseEntity
    {
        public string Nome { get; set; }

        public string numeroConta { get; set; }

        public string senha { get; set; }

        public decimal saldo { get; set; }
    }
}
