using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntidadesExtraordinario
{
    class CObra
    {
        public string Nom_Obra { get; set; }
        public string Direccion { get; set; }
        public DateTime Fecha_Inicio { get; set; }
        public DateTime Fecha_Termino { get; set; }
        public int ID_Dueno { get; set; }
        public int ID_Encargado { get; set; }
    }
}
