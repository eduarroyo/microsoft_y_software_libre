using System;
using System.Collections.Generic;

namespace taskslist.Models
{
    public partial class Tareas
    {
        public long TareaId { get; set; }
        public string Tarea { get; set; }
        public bool Resuelta { get; set; }
        public string Usuario { get; set; }
        public DateTime CreadoFecha { get; set; }
        public DateTime ModificadoFecha { get; set; }
    }
}
