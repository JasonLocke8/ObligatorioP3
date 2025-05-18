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
        public int? UsuarioId { get; set; }
        public string? Accion { get; set; }
        public string? Entidad { get; set; }
        public string? EntidadId { get; set; }
        public string? Observaciones { get; set; }
        public DateTime Fecha { get; set; }

        public Auditoria()
        {
            Fecha = DateTime.Now;
        }
        public Auditoria(int? usuarioId, string accion, string entidad, string entidadId, string observaciones)
        {
            UsuarioId = usuarioId;
            Accion = accion;
            Entidad = entidad;
            EntidadId = entidadId;
            Observaciones = observaciones;
            Fecha = DateTime.Now;
        }

    }
}
