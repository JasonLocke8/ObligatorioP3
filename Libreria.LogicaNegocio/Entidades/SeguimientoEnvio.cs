using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Libreria.LogicaNegocio.Entidades
{
    public class SeguimientoEnvio
    {
        public int Id { get; set; }
        public int EnvioId { get; set; }
        public Envio Envio { get; set; }
        public string Comentario { get; set; }
        public DateTime FechaComentario { get; set; }
        public Usuario ComentarioEmpleado { get; set; }
        public SeguimientoEnvio(Envio envio, string comentario, Usuario comentarioEmpleado)
        {
            Envio = envio;
            Comentario = comentario;
            FechaComentario = DateTime.Now;
            ComentarioEmpleado = comentarioEmpleado;
            Validar();
        }

        public SeguimientoEnvio()
        {
        }

        public void Validar()
        {
            if (Envio == null)
            {
                throw new Exception("El envío no puede ser nulo.");
            }
            if (String.IsNullOrEmpty(Comentario))
            {
                throw new Exception("El comentario no puede ser vacío.");
            }
            if (ComentarioEmpleado == null)
            {
                throw new Exception("El empleado que realizó el comentario no puede ser nulo.");
            }
        }
    }
}
