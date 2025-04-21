using Libreria.LogicaNegocio.Enumerados;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Libreria.LogicaNegocio.Entidades
{
    public class Auditoria
    {
        public int Id { get; set; }

        // Quien hizo la accion
        public int UsuarioId { get; set; }
        public DateTime FechaAccion { get; set; }
        public AuditoriaEmpleados TipoAccion { get; set; }

        // Id de la entidad afectada
        public int EntidadId { get; set; }
        public string Descripcion { get; set; }

        public Auditoria (int usuarioId, DateTime fechaAccion, AuditoriaEmpleados tipoAccion, int entidadId, string descripcion)
        {
            UsuarioId = usuarioId;
            FechaAccion = fechaAccion;
            TipoAccion = tipoAccion;
            EntidadId = entidadId;
            Descripcion = descripcion;
        }

    }
}
