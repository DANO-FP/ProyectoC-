using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Entidades;
using Persistencia;

namespace Logica
{
    public interface ILogicaZona
    {
        Zona BuscarZona(string dep, string acronimo);
        void AltaZona(Zona z);
        void BajaZona(Zona z);
        void ModificaZona(Zona z);
        void ModificarServicios(Zona z);
       

    }
}