﻿using Libreria.DTOs.DTOs.DTOsUsuario;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Libreria.LogicaAplicacion.InterfacesCasosUso.ICUUsuario
{
    public interface ICUListarUsuario
    {
        List<DTOUsuario> ListarUsuario();

        DTOUsuario ListarUsuarioPorId(int id);
    }
}
