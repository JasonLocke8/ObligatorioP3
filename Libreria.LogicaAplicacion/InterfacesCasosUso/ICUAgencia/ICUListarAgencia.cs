﻿using Libreria.DTOs.DTOs.DTOsAgencia;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Libreria.LogicaAplicacion.InterfacesCasosUso.ICUAgencia
{
    public interface ICUListarAgencia
    {
        List<DTOAgencia> ListarAgencia();
        DTOAgencia ListarAgenciaPorId(int id);
    }
}
