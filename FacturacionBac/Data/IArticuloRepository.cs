﻿using Facturacion1._5.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Facturacion1._5.Data.Implementations
{
    public interface IArticuloRepository
    {
        List<Articulo> ObtenerArticulo();
        bool ActuaslizarArticulo(Articulo articulo);
        bool BorrarArticulo(int id);
        bool InsertarArticulo(Articulo articulo);
    }
}
