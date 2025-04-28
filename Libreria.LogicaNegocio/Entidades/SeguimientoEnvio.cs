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
        }

        public SeguimientoEnvio()
        {
        }
    }
}
