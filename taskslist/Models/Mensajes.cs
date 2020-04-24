using System;
using System.Collections.Generic;

namespace taskslist.Models
{
    public partial class Mensajes
    {
        public long MensajeId { get; set; }
        public string Mensaje { get; set; }
        public DateTime FechaEnvio { get; set; }
        public string Remitente { get; set; }
    }
}
