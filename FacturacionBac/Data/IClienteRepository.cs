﻿using Facturacion1._5.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Facturacion1._5.Data.Implementations
{
    public interface IClienteRepository
    {
        List<Cliente> ObtenerClientes();
        public bool InsertarCliente(Cliente cliente);
    }
}
