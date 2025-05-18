using Libreria.LogicaAplicacion.InterfacesCasosUso.ICUEnvios;
using Libreria.LogicaNegocio.CustomExceptions.EnvioExceptions;
using Libreria.LogicaNegocio.Entidades;
using Libreria.LogicaNegocio.Enumerados;
using Libreria.LogicaNegocio.InterfacesRepositorios;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace Libreria.LogicaAplicacion.CasosUso.CUEnvios
{
    public class CUFinalizarEnvio : ICUFinalizarEnvio
    {

        private IRepositorioEnvio _repositorioEnvio;
        private IRepositorioAuditoria _repositorioAuditoria;

        public CUFinalizarEnvio(IRepositorioEnvio repositorioEnvio, IRepositorioAuditoria repositorioAuditoria)
        {
            _repositorioEnvio = repositorioEnvio;
            _repositorioAuditoria = repositorioAuditoria;
        }


        public void FinalizarEnvio(int id, int logueadoId)
        {
            try
            {
                if (!_repositorioEnvio.ExisteEnvio(id))
                {
                    throw new EnvioNoExisteException("El envio no existe");
                }

                Envio envioBuscado = _repositorioEnvio.FindById(id);

                if (envioBuscado == null)
                {
                    throw new EnvioNoExisteException("El envio no existe");
                }

                envioBuscado.Estado = EstadoEnvio.FINALIZADO;

                envioBuscado.FechaEntrega = DateTime.Now;

                if (envioBuscado is EnvioUrgente envioUrgente)
                {
                    envioUrgente.EvaluarEficienciaEntrega();
                }

                _repositorioEnvio.Update(envioBuscado);

                Auditoria aud = new Auditoria(logueadoId, "UPDATE", "ENVIO", envioBuscado.ClienteId.ToString(), JsonSerializer.Serialize(envioBuscado));
                _repositorioAuditoria.Auditar(aud);

            }
            catch (Exception e)
            {
                Auditoria aud = new Auditoria(logueadoId, "UPDATE", "ENVIO", null, e.Message);
                _repositorioAuditoria.Auditar(aud);

                throw e;
            }

        }
    }
}
