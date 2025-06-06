﻿using Libreria.DTOs.DTOs.DTOsEnvio;
using Libreria.DTOs.Mappers;
using Libreria.LogicaAplicacion.InterfacesCasosUso.ICUEnvios;
using Libreria.LogicaNegocio.Entidades;
using Libreria.LogicaNegocio.InterfacesRepositorios;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Libreria.LogicaAplicacion.CasosUso.CUEnvios
{
    public class CUListarEnvio : ICUListarEnvio
    {

        private IRepositorioEnvio _repositorioEnvio;

        public CUListarEnvio(IRepositorioEnvio repositorioEnvio)
        {
            _repositorioEnvio = repositorioEnvio;
        }
        public List<DTOEnvio> ListarEnvios()
        {
            List<Envio> envio = _repositorioEnvio.FindEnviosEnProceso();

            List<DTOEnvio> listaDTO = MapperEnvio.FromListEnvioToListDTOEnvio(envio);

            return listaDTO;
        }

        public DTOEnvio ListarEnvioPorId(int id)
        {

            Envio envio = _repositorioEnvio.FindById(id);

            DTOEnvio dto = MapperEnvio.FromEnvioToDTOEnvio(envio);

            return dto;

        }

    }
}

